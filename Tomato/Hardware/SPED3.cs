using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;

namespace Tomato.Hardware
{
    public enum SPED3State
    {
        STATE_NO_DATA = 0,
        STATE_RUNNING = 1,
        STATE_TURNING = 2
    }

    public class SPED3 : Device
    {
        public SPED3()
        {
            rotationTimer = new Timer(UpdateRotation, null, 16, 16); // Updates at 60 Hz
        }

        private Timer rotationTimer;
        private void UpdateRotation(object discarded)
        {
            if (TargetRotation != CurrentRotation)
            {
                if (TargetRotation < CurrentRotation)
                    CurrentRotation -= 0.8f; // Rotates at roughly 0.8 degrees per cycle
                else
                    CurrentRotation += 0.8f;
            }
        }

        public event EventHandler VerticiesChanged;

        [ReadOnly(true)]
        public SPED3State State { get; set; }

        [Category("Device Status")]
        public ushort TargetRotation { get; set; }

        [Browsable(false)]
        public float CurrentRotation { get; set; }

        [Category("Device Status")]
        public ushort MemoryMap { get; set; }

        [Category("Device Status")]
        public ushort TotalVerticies { get; set; }

        [Category("Device Information")]
        public override uint DeviceID
        {
            get { return 0x42babf3c; }
        }

        [Category("Device Information")]
        public override uint ManufacturerID
        {
            get { return 0x1eb37e91; }
        }

        [Category("Device Information")]
        public override ushort Version
        {
            get { return 0x0003; }
        }

        [Browsable(false)]
        public override string FriendlyName
        {
            get { return "Mackapar Suspended Particle Exciter Display, Rev 3"; }
        }

        public SPED3Vertex[] Verticies
        {
            get
            {
                var verticies = new SPED3Vertex[TotalVerticies];
                for (ushort i = 0; i < TotalVerticies; i++)
                    verticies[i] = new SPED3Vertex(AttachedCPU.Memory[MemoryMap + i]);
                return verticies;
            }
        }

        public override int HandleInterrupt()
        {
            switch (AttachedCPU.A)
            {
                case 0:
                    AttachedCPU.B = (ushort)State;
                    AttachedCPU.C = 0; // Proper emulation of errors is unknown
                    break;
                case 1:
                    MemoryMap = AttachedCPU.X;
                    TotalVerticies = AttachedCPU.Y;
                    if (TotalVerticies != 0)
                        State = SPED3State.STATE_RUNNING;
                    if (VerticiesChanged != null)
                        VerticiesChanged(this, null); // To notify applications when to rebuild the vertex buffer
                    break;
                case 3:
                    TargetRotation = (ushort)(AttachedCPU.X % 360);
                    if (TargetRotation != CurrentRotation)
                        State = SPED3State.STATE_TURNING;
                    break;
            }
            return 0;
        }

        public override void Reset()
        {
            TotalVerticies = 0;
            MemoryMap = 0;
            State = SPED3State.STATE_NO_DATA;
        }
    }

    public struct SPED3Vertex
    {
        public byte X;
        public byte Y;
        public byte Z;
        public byte Color;

        public SPED3Vertex(ushort value)
        {
            X = (byte)(value & 0x1F);
            Y = (byte)((value >> 5) & 0x1F);
            Z = (byte)((value >> 10) & 0x1F);
            Color = (byte)((value >> 15) & 1);
        }

        public string ToString()
        {
            return "<" + X + "," + Y + "," + Z + "> " +
                (Color == 0 ? "Green" : "Red");
        }
    }
}
