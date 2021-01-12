using System;
using System.Collections.Generic;
using System.Text;

namespace ProtocolModbus
{
    class SetSignalValueRsp
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public SetSignalValueRsp(byte[] rspBytes)
        {
            if (rspBytes.Length < 3)
            {
                Success = false;
                Message = "长度不够";
                return;
            }
            var crc = Utils.CRC.Crc16(rspBytes, rspBytes.Length - 2);
            if (!(crc[0] == rspBytes[rspBytes.Length - 2] && crc[1] == rspBytes[rspBytes.Length - 1]))
            {
                Success = false;
                Message = "CRC校验失败";
                return;
            }
            Success = true;
        }
    }
}
