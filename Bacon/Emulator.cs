using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using Tomato;

namespace Bacon
{
    public class Emulator
    {
        public List<TcpClient> Clients { get; set; }
        public DCPU CPU { get; set; }

        public Emulator()
        {
            CPU = new DCPU();
        }
    }
}
