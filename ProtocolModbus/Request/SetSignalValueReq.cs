using ProtocolsInterface;
using System;
using System.Collections.Generic;
using System.Text;
using TopPortLib.Interfaces;

namespace ProtocolModbus
{
    class SetSignalValueReq : BaseSetReq, IByteStream
    {
        public SetSignalValueReq(byte deviceAddress, UInt16 registerAddress, byte[] data) : base(deviceAddress, registerAddress, data) { }
    }
}
