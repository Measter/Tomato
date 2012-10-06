using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.IO;

namespace Tomato.Hardware
{
    public class M35FD : Device
    {
        public M35FD()
        {

        }

        public ushort[] Disk { get; private set; }
        [Category("Disk Information")]
        public bool Writable { get; set; }

        [Category("Device Status")]
        public M35FDErrorCode LastError
        {
            get
            {
                return lastError;
            }
            set
            {
                lastError = value;
                if (InterruptMessage != 0)
                    AttachedCPU.FireInterrupt(InterruptMessage);
            }
        }
        private M35FDErrorCode lastError;
        [Category("Device Status")]
        public ushort InterruptMessage { get; set; }
        [Category("Device Status")]
        public M35FDStateCode DeviceState 
        {
            get
            {
                return deviceState;
            }
            set
            {
                deviceState = value;
                if (InterruptMessage != 0)
                    AttachedCPU.FireInterrupt(InterruptMessage);
            }
        }
        private M35FDStateCode deviceState;

        [Category("Device Information")]
        [TypeConverter(typeof(HexTypeEditor))]
        public override uint DeviceID
        {
            get { return 0x7349f615; }
        }

        [Category("Device Information")]
        [TypeConverter(typeof(HexTypeEditor))]
        public override uint ManufacturerID
        {
            get { return 0x1eb37e91; }
        }

        [Category("Device Information")]
        [TypeConverter(typeof(HexTypeEditor))]
        public override ushort Version
        {
            get { return 0x000b; }
        }

        [Browsable(false)]
        public override string FriendlyName
        {
            get { return "3.5\" Floppy Drive (M35FD)"; }
        }

        public override int HandleInterrupt()
        {
            switch (AttachedCPU.A)
            {
                case 0: // Poll device
                    AttachedCPU.B = (ushort)DeviceState;
                    AttachedCPU.C = (ushort)LastError;
                    break;
                case 1: // Set interrupt
                    InterruptMessage = AttachedCPU.X;
                    break;
                case 2:
                    
                    break;
            }
            return 0;
        }

        public void InsertDisk(ushort[] disk, bool writable)
        {
            if (disk.Length != 737280)
                throw new IOException("Invalid disk size.");
            Disk = disk;
            Writable = writable;
            if (writable)
                DeviceState = M35FDStateCode.STATE_READY;
            else
                DeviceState = M35FDStateCode.STATE_READY_WP;
        }

        public void Eject()
        {
            if (Disk == null)
                throw new IOException("No disk present.");
            Disk = null;
            DeviceState = M35FDStateCode.STATE_NO_MEDIA;
        }

        public override void Reset()
        {
            
        }
    }

    public enum M35FDStateCode
    {
        STATE_NO_MEDIA = 0,
        STATE_READY = 1,
        STATE_READY_WP = 2
    }

    public enum M35FDErrorCode
    {
        ERROR_NONE = 0,
        ERROR_BUSY = 1,
        ERROR_NO_MEDIA = 2,
        ERROR_PROTECTED = 3,
        ERROR_EJECT = 4,
        ERROR_BAD_SECTOR = 5,
        ERROR_BROKEN = 6
    }
}
