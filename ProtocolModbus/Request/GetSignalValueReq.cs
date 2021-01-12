using System;
using System.Collections.Generic;
using System.Text;
using TopPortLib.Interfaces;

namespace ProtocolModbus
{
    internal class GetSignalValueReq : BaseGetReq, IByteStream
    {
        public GetSignalValueReq(byte deviceAddress, UInt16 registerAddress, UInt16 registerCount) : base(deviceAddress, registerAddress, registerCount) { }
    }
}
