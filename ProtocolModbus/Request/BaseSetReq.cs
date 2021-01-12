using ProtocolsInterface;
using System;
using System.Collections.Generic;
using System.Text;
using TopPortLib.Interfaces;
using Utils;

namespace ProtocolModbus
{
    abstract class BaseSetReq : IByteStream
    {
        private byte _deviceAddress;
        private UInt16 _registerAddress;
        private byte[] _data;

        public BaseSetReq(byte deviceAddress, UInt16 registerAddress, byte[] data)
        {
            _deviceAddress = deviceAddress;
            _registerAddress = registerAddress;
            _data = data;
        }

        public byte[] ToBytes()
        {
            var dataLength = BitConverter.GetBytes(_data.Length / 2);
            var byteCount = (byte)_data.Length;
            var startAddr = StringByteUtils.GetBytes(_registerAddress, true);
            var head = new byte[]
            {
                _deviceAddress,
                0x10,
                startAddr[0],
                startAddr[1],
                dataLength[1],
                dataLength[0],
                byteCount
            };
            var temp = StringByteUtils.ComibeByteArray(head, _data);
            var crc = CRC.Crc16(temp, temp.Length);
            return StringByteUtils.ComibeByteArray(temp, crc);
        }
    }
}
