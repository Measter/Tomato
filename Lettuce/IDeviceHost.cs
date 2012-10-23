using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tomato.Hardware;

namespace Lettuce
{
    public interface IDeviceHost
    {
        Device[] ManagedDevices { get; }
    }
}
