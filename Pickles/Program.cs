using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tomato;
using System.IO;
using Tomato.Hardware;
using System.Reflection;
using System.Globalization;
using System.Threading;
using System.Diagnostics;

namespace Pickles
{
    public class Program
    {
        static List<Device> PossibleDevices = new List<Device>();
        static int ConsoleID = 0;
        static Timer ClockTimer;
        public static DCPU CPU;
        public static DateTime LastTick;
        public static Dictionary<string, string> Shortcuts = new Dictionary<string, string>();

        [STAThread]
        static void Main(string[] args)
        {
            Console.Clear();
            Console.TreatControlCAsInput = true;

            Console.WriteLine("Pickles DCPU-16 Debugger     Copyright Drew DeVault 2012");
            Console.WriteLine("Use \"help\" for assistance.");

            foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                var types = asm.GetTypes().Where(t => typeof(Device).IsAssignableFrom(t) && t.IsAbstract == false);
                foreach (var type in types)
                    PossibleDevices.Add((Device)Activator.CreateInstance(type));
            }

            string input;
            CPU = new DCPU();
            CPU.BreakpointHit += CPU_BreakpointHit;
            CPU.InvalidInstruction += CPU_InvalidInstruction;
            CPU.IsRunning = false;
            LastTick = DateTime.Now;
            ClockTimer = new System.Threading.Timer(FetchExecute, null, 10, Timeout.Infinite);
            while (true)
            {
                Console.Write(">");
                string originalInput = ReadLineEnableShortcuts().Trim();
                ParseInput(originalInput);
                if (originalInput.ToLower() == "quit" || originalInput.ToLower() == "q")
                    break;
            }
        }

        static void CPU_InvalidInstruction(object sender, InvalidInstructionEventArgs e)
        {
            Console.Write("Invalid instruction executed: 0x" + e.Instruction.ToString("X4") + " at 0x" + e.Address.ToString("X4") + "\n>");
            e.ContinueExecution = false;
            CPU.IsRunning = false;
        }

        static void CPU_BreakpointHit(object sender, BreakpointEventArgs e)
        {
            e.ContinueExecution = false;
            CPU.IsRunning = false;
            Console.WriteLine("Breakpoint hit: 0x" + e.Breakpoint.Address.ToString("X4"));
            ParseInput("dasm"); ParseInput("list registers"); Console.Write(">");
        }

        private static void ParseInput(string originalInput)
        {
            string input = originalInput.ToLower().Trim();
            string[] parameters = input.Split(' ');

            if (input == "clear")
                Console.Clear();
            else if (input.StartsWith("bind "))
            {
                string[] parts = input.Split(' ');
                Shortcuts.Add(parts[1].ToLower(), input.Substring(5 + parts[1].Length));
            }
            else if (input.StartsWith("flash "))
            {
                bool littleEndian = false;
                string file;
                if (parameters.Length == 2)
                    file = parameters[1];
                else if (parameters.Length == 3)
                {
                    file = parameters[2];
                    littleEndian = parameters[1].ToLower() == "little";
                }
                else
                    return;
                List<ushort> data = new List<ushort>();
                using (Stream stream = File.OpenRead(file))
                {
                    for (int i = 0; i < stream.Length; i += 2)
                    {
                        byte a = (byte)stream.ReadByte();
                        byte b = (byte)stream.ReadByte();
                        if (littleEndian)
                            data.Add((ushort)(a | (b << 8)));
                        else
                            data.Add((ushort)(b | (a << 8)));
                    }
                }
                CPU.FlashMemory(data.ToArray());
            }
            else if (input.StartsWith("connect "))
                ConnectDevice(input.Substring(8));
            else if (input == "start")
                CPU.IsRunning = true;
            else if (input == "stop")
                CPU.IsRunning = false;
            else if (input.StartsWith("step"))
            {
                if (CPU.IsRunning)
                {
                    Console.WriteLine("CPU is still running; use \"stop\" first.");
                    return;
                }
                string[] parts = input.Split(' ');
                if (parts.Length > 1)
                {
                    if (parts[1] == "into" || parts[1] == "once")
                        CPU.Execute(-1);
                    else if (parts[1] == "over")
                    {
                    }
                    else
                    {
                        int i = int.Parse(parts[1]);
                        while (i > 0)
                        {
                            CPU.Execute(-1);
                            i--;
                        }
                    }
                }
                else
                    CPU.Execute(-1);
            }
            else if (input.StartsWith("dump "))
            {
                string[] parts = input.Substring(5).Split(' ');
                if (parts[0] == "screen")
                {
                    if (parts.Length > 1)
                    {
                        int index = int.Parse(parts[1]);
                        if (CPU.Devices[index] is LEM1802)
                            DrawScreen(CPU.Devices[index] as LEM1802);
                    }
                    else
                    {
                        foreach (var device in CPU.Devices)
                            if (device is LEM1802)
                            {
                                DrawScreen(device as LEM1802);
                                break;
                            }
                    }
                }
                else if (parts[0] == "memory" || parts[0] == "mem")
                {
                    ushort start = 0;
                    if (parts.Length > 1)
                        start = ushort.Parse(parts[1], NumberStyles.HexNumber);
                    ushort end = (ushort)(start + 0x40);
                    if (parts.Length > 2)
                        end = ushort.Parse(parts[2], NumberStyles.HexNumber);
                    int index = 0;
                    while (start < end)
                    {
                        if (index % 8 == 0)
                            Console.Write("0x" + GetHexString(start, 4) + ": ");
                        if (CPU.PC == start)
                            Console.Write("[" + GetHexString(CPU.Memory[start], 4) + "]");
                        else
                            Console.Write(" " + GetHexString(CPU.Memory[start], 4) + " ");
                        if (index % 8 == 7)
                            Console.Write("\n");
                        index++;
                        start++;
                    }
                }
                else if (parts[0] == "stack")
                {
                    ushort address = CPU.SP;
                    for (ushort i = 0; i < 10; i++)
                    {
                        Console.WriteLine("[" + GetHexString(address, 4) + "]: " + GetHexString(CPU.Memory[address], 4));
                        address++;
                    }
                }
            }
            else if (input.StartsWith("list "))
            {
                string[] parts = input.Split(' ');
                if (parts[1] == "registers")
                {
                    Console.Write("A:  " + GetHexString(CPU.A, 4));
                    Console.Write("   B:  " + GetHexString(CPU.B, 4) + "\n");
                    Console.Write("C:  " + GetHexString(CPU.C, 4));
                    Console.Write("   X:  " + GetHexString(CPU.X, 4) + "\n");
                    Console.Write("Y:  " + GetHexString(CPU.Y, 4));
                    Console.Write("   Z:  " + GetHexString(CPU.Z, 4) + "\n");
                    Console.Write("I:  " + GetHexString(CPU.I, 4));
                    Console.Write("   J:  " + GetHexString(CPU.J, 4) + "\n");
                    Console.Write("PC: " + GetHexString(CPU.PC, 4));
                    Console.Write("   SP: " + GetHexString(CPU.SP, 4) + "\n");
                    Console.Write("EX: " + GetHexString(CPU.EX, 4));
                    Console.Write("   IA: " + GetHexString(CPU.IA, 4) + "\n");
                }
                else if (parts[1] == "hardware")
                {
                    int i = 0;
                    foreach (var hw in CPU.Devices)
                        Console.WriteLine((i++) + ": " + hw.FriendlyName + " (0x" + hw.DeviceID.ToString("X8") + ")");
                }
            }
            else if (input.StartsWith("dasm") || input.StartsWith("dis"))
            {
                FastDisassembler fdas = new FastDisassembler(new Dictionary<ushort, string>());
                ushort start = (ushort)(CPU.PC - 2);
                string[] parts = input.Split(' ');
                if (parts.Length > 1)
                    start = ushort.Parse(parts[1], NumberStyles.HexNumber);
                var code = fdas.FastDisassemble(ref CPU.Memory, start, (ushort)(start + 0x10));
                foreach (var entry in code)
                {
                    if (CPU.PC == entry.Address)
                    {
                        ConsoleColor background = Console.BackgroundColor;
                        ConsoleColor foreground = Console.ForegroundColor;
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(GetHexString(entry.Address, 4) + ": " + entry.Code);
                        Console.ForegroundColor = foreground;
                        Console.BackgroundColor = background;
                    }
                    else if (CPU.Breakpoints.Where(b => b.Address == entry.Address).Count() != 0)
                    {
                        ConsoleColor background = Console.BackgroundColor;
                        ConsoleColor foreground = Console.ForegroundColor;
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(GetHexString(entry.Address, 4) + ": " + entry.Code);
                        Console.ForegroundColor = foreground;
                        Console.BackgroundColor = background;
                    }
                    else
                        Console.WriteLine(GetHexString(entry.Address, 4) + ": " + entry.Code);
                }
            }
            else if (input.StartsWith("breakpoint "))
            {
                string[] parts = input.Split(' ');
                ushort address = ushort.Parse(parts[2], NumberStyles.HexNumber);
                if (parts[1] == "add" || parts[1] == "set")
                {
                    if (CPU.Breakpoints.Count(b => b.Address == address) == 0)
                    {
                        CPU.Breakpoints.Add(new Breakpoint()
                        {
                            Address = ushort.Parse(input.Substring(11), NumberStyles.HexNumber)
                        });
                    }
                    else
                        Console.WriteLine("There is already a breakpoint set at that address.");
                }
                else if (parts[1] == "remove")
                {
                    if (CPU.Breakpoints.Count(b => b.Address == address) != 0)
                        CPU.Breakpoints.Remove(CPU.Breakpoints.FirstOrDefault(b => b.Address == address));
                    else
                        Console.WriteLine("There is no breakpoint set at that address.");
                }
            }
            else if (input == "exit" || input == "quit" || input == "bye")
                Process.GetCurrentProcess().Kill();
            else if (input.StartsWith("help"))
                DoHelp(input);
            else if (input == "") { }
            else
            {
                if (File.Exists(input)) // Script?
                {
                    string[] file = File.ReadAllLines(input);
                    foreach (var line in file)
                        ParseInput(line);
                }
                else
                    Console.WriteLine("Unknown command.");
            }
            return;
        }

        private static void DoHelp(string input)
        {
            if (input == "help")
            {
                Console.WriteLine("For help on a specific command, use help [command].\n" +
                    "The following commands are available:\n" +
                    "    bind, breakpoint, clear, connect, dasm, dump, exit, flash, list,\n    start, step, stop");
            }
            else
            {
                string command = input.Substring(5);
                switch (command)
                {
                    case "bind":
                        Console.WriteLine("$ bind [key] [command...]\n" +
                            "Binds the specified [key] to [command...] and executes [command...]\nwhen pressed in conjunction with [Ctrl].");
                        break;
                    case "breakpoint":
                        Console.WriteLine("$ breakpoint [add|remove] [address]\n" +
                            "Adds or removes a breakpoint at [address], specified in hexadecimal.");
                        break;
                    case "clear":
                        Console.WriteLine("$ clear\n" +
                            "Clears the console.");
                        break;
                    case "connect":
                        Console.WriteLine("$ connect [hardware...]\n" +
                            "Connects hardware to the CPU. [hardware...] is a comma-delimited list of\n" +
                            "devices. You may use the device name (such as \"LEM1802\"), or the hardware ID,\n" +
                            "in hexadecimal. Example: $ connect LEM1802,genericclock,30cf7406");
                        break;
                    case "dasm":
                        Console.WriteLine("$ dasm (start address)\n" +
                            "Displays a disassembly of memory. If (start address) is not provided,\n" +
                            "PC will be used. 0x10 words of memory are displayed. PC is shown with\n" +
                            "a yellow background, and breakpoints are shown in red.");
                        break;
                    case "dump":
                        Console.WriteLine("See \"help dump memory\", \"help dump stack\", and \"help dump screen\".");
                        break;
                    case "dump memory":
                        Console.WriteLine("$ dump memory [start address] (end address)\n" +
                            "Outputs a segment of memory to the console. (end address) defaults to\n" +
                            "[start address] + 0x40. PC is shown with brackets around the cell.");
                        break;
                    case "dump stack":
                        Console.WriteLine("$ dump stack\n" +
                            "Outputs the first 10 words on the stack.");
                        break;
                    case "dump screen":
                        Console.WriteLine("$ dump screen [index]\n" +
                            "Outputs a textual representation of the LEM-1802 device at [index].");
                        break;
                    case "exit":
                        Console.WriteLine("$ exit\n" +
                            "Exits Pickles.");
                        break;
                    case "flash":
                        Console.WriteLine("$ flash (little|big) [file]\n" +
                            "Inserts the contents of [file] into memory. If an endianness is not specified, big-\n" +
                            "endian is the default.");
                        break;
                    case "list":
                        Console.WriteLine("See \"help list registers\" and \"help list hardware\".");
                        break;
                    case "list hardware":
                        Console.WriteLine("$ list hardware\n" +
                            "Displays a list of all connected devices, as well as their hadware IDs.");
                        break;
                    case "list registers":
                        Console.WriteLine("$ list registers\n" +
                            "Lists all registers and their values.");
                        break;
                    case "start":
                        Console.WriteLine("$ start\n" +
                            "Starts the CPU at 60 Hz.");
                        break;
                    case "stop":
                        Console.WriteLine("$ stop\n" +
                            "Stops CPU execution.");
                        break;
                    default:
                        Console.WriteLine("Unrecognized command.");
                        break;
                }
            }
        }

        private static List<string> History = new List<string>();
        public static string ReadLineEnableShortcuts()
        {
            string entry = "";
            int cursor = 0, historyEntry = -1, curLeft = Console.CursorLeft, curTop = Console.CursorTop;
            while (true)
            {
                // TODO: Support scrolling across newlines and window boundaries
                var keyinfo = Console.ReadKey(true);
                if (keyinfo.Modifiers == ConsoleModifiers.Control)
                {
                    if (Shortcuts.ContainsKey(keyinfo.Key.ToString().ToLower()))
                        ParseInput(Shortcuts[keyinfo.Key.ToString().ToLower()]);
                    continue;
                }
                if (keyinfo.Key == ConsoleKey.Enter)
                    break;
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (cursor > 0)
                    {
                        Console.CursorLeft--;
                        cursor--;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (cursor < entry.Length)
                    {
                        Console.CursorLeft++;
                        cursor++;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    Console.SetCursorPosition(curLeft, curTop);
                    for (int i = 0; i < entry.Length; i++)
                        Console.Write(" ");
                    historyEntry++;
                    if (historyEntry > History.Count - 1)
                        historyEntry--;
                    Console.SetCursorPosition(curLeft, curTop);
                    Console.Write(History.ElementAt(historyEntry));
                    entry = History.ElementAt(historyEntry);
                    cursor = entry.Length - 1;
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    Console.SetCursorPosition(curLeft, curTop);
                    for (int i = 0; i < entry.Length; i++)
                        Console.Write(" ");
                    historyEntry--;
                    if (historyEntry < -1)
                        historyEntry++;
                    if (historyEntry == -1)
                        entry = "";
                    else
                    {
                        entry = History.ElementAt(historyEntry);
                        cursor = entry.Length - 1;
                    }
                    Console.SetCursorPosition(curLeft, curTop);
                    Console.Write(entry);
                }
                else if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    if (cursor > 0)
                    {
                        Console.CursorLeft--;
                        cursor--;
                        entry = entry.Remove(cursor, 1);
                        int left = Console.CursorLeft;
                        Console.Write(entry.Substring(cursor) + " ");
                        Console.CursorLeft = left;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Delete)
                {
                    if (cursor < entry.Length)
                    {
                        entry = entry.Remove(cursor, 1);
                        int left = Console.CursorLeft;
                        Console.Write(entry.Substring(cursor) + " ");
                        Console.CursorLeft = left;
                    }
                }
                else
                {
                    entry = entry.Insert(cursor, keyinfo.KeyChar.ToString());
                    cursor++;
                    int left = Console.CursorLeft;
                    Console.Write(entry.Substring(cursor - 1));
                    Console.CursorLeft = left + 1;
                }
            }
            if (History.Count == 20)
                History.RemoveAt(History.Count - 1);
            History.Insert(0, entry);
            Console.Write("\n");
            return entry;
        }

        public static string GetHexString(uint value, int numDigits)
        {
            string result = value.ToString("x").ToUpper();
            while (result.Length < numDigits)
                result = "0" + result;
            return result;
        }

        private static void DrawScreen(LEM1802 Screen)
        {
            ConsoleColor foregroundInitial = Console.ForegroundColor;
            ConsoleColor backgroundInitial = Console.BackgroundColor;
            ushort address = 0;
            Console.ForegroundColor = GetPaletteColor((byte)Screen.BorderColorValue);
            Console.Write("                                  \n");
            for (int y = 0; y < 12; y++)
            {
                Console.ForegroundColor = GetPaletteColor((byte)Screen.BorderColorValue);
                Console.Write(" ");
                for (int x = 0; x < 32; x++)
                {
                    ushort value = CPU.Memory[Screen.ScreenMap + address];

                    ConsoleColor background = GetPaletteColor((byte)((value & 0xF00) >> 8));
                    ConsoleColor foreground = GetPaletteColor((byte)((value & 0xF000) >> 12));
                    Console.ForegroundColor = foreground;
                    Console.BackgroundColor = background;
                    Console.Write(Encoding.ASCII.GetString(new byte[] { (byte)(value & 0xFF) }));
                    address++;
                }
                Console.ForegroundColor = GetPaletteColor((byte)Screen.BorderColorValue);
                Console.Write(" \n");
            }
            Console.ForegroundColor = foregroundInitial;
            Console.BackgroundColor = backgroundInitial;
        }

        private static ConsoleColor GetPaletteColor(byte p)
        {
            p &= 0xF;
            return new ConsoleColor[]
            {
                ConsoleColor.Black,
                ConsoleColor.Blue,
                ConsoleColor.Green,
                ConsoleColor.DarkCyan,
                ConsoleColor.DarkRed,
                ConsoleColor.Magenta,
                ConsoleColor.DarkYellow,
                ConsoleColor.Gray,
                ConsoleColor.DarkGray,
                ConsoleColor.Cyan,
                ConsoleColor.Green,
                ConsoleColor.Blue,
                ConsoleColor.Magenta,
                ConsoleColor.Magenta,
                ConsoleColor.Yellow,
                ConsoleColor.White
            }[p];
        }

        private static void FetchExecute(object o)
        {
            if (!CPU.IsRunning)
            {
                ClockTimer = new System.Threading.Timer(FetchExecute, null, 10, Timeout.Infinite);
                LastTick = DateTime.Now;
                return;
            }
            TimeSpan timeToEmulate = DateTime.Now - LastTick;
            LastTick = DateTime.Now;

            CPU.Execute((int)(timeToEmulate.TotalMilliseconds * (CPU.ClockSpeed / 1000)));
            ClockTimer = new System.Threading.Timer(FetchExecute, null, 10, Timeout.Infinite);
        }

        private static void ConnectDevice(string device)
        {
            string[] ids = device.Split(',');
            foreach (var dID in ids)
            {
                uint id;
                if (uint.TryParse(dID, NumberStyles.HexNumber, null, out id))
                {
                    foreach (Device d in PossibleDevices)
                    {
                        if (d.DeviceID == id)
                            CPU.ConnectDevice((Device)Activator.CreateInstance(d.GetType()));
                    }
                }
                else
                {
                    foreach (Device d in PossibleDevices)
                    {
                        if (d.GetType().Name.ToLower() == dID.ToLower())
                            CPU.ConnectDevice((Device)Activator.CreateInstance(d.GetType()));
                    }
                }
            }
        }
    }
}
