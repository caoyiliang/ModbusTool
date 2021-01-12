using System;
using System.Collections.Generic;
using System.Text;
using TopPortLib.Interfaces;

namespace ProtocolModbus
{
    internal abstract class BaseGetReq : IByteStream
    {
        private byte _deviceAddress;
        private UInt16 _registerAddress;
        private UInt16 _registerCount;
        public BaseGetReq(byte deviceAddress, UInt16 registerAddress, UInt16 registerCount)
        {
            _deviceAddress = deviceAddress;
            _registerAddress = registerAddress;
            _registerCount = registerCount;
        }

        public byte[] ToBytes()
        {
            var bytes = Utils.StringByteUtils.ComibeByteArray(new byte[] { _deviceAddress, 0x03 }, Utils.StringByteUtils.GetBytes(_registerAddress, true), Utils.StringByteUtils.GetBytes(_registerCount, true));
            var crc = Utils.CRC.Crc16(bytes, bytes.Length);
            return Utils.StringByteUtils.ComibeByteArray(bytes, crc);
        }
    }
}
