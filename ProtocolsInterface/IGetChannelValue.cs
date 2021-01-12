using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TopPortLib.Interfaces;

namespace ProtocolsInterface
{
    public interface IGetChannelValue
    {
        Task<GetChannelValueRsp> GetSignalValueAsync(ICrowPort crowPort, string address);
    }
}
