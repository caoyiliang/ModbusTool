using DataPairs;
using DataPairs.Interfaces;
using ProtocolsInterface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusTool.Protocol
{
    public class ProtocolConfig
    {
        private static readonly IDataPair<ProtocolConfig> pair = new DataPair<ProtocolConfig>("ProtocolConfig",StorageType.File);

        public List<ProtocolComponent> Protocols { get; set; } = new List<ProtocolComponent>();

        public static async Task<ProtocolConfig> GetValueAsync()
        {
            var protocolConfigs = await pair.TryGetValueAsync();
            return protocolConfigs;
        }

        public static async Task TrySaveChangeAsync(ProtocolConfig protocolConfig)
        {
            await pair.TryInitOrUpdateAsync(protocolConfig);
        }
    }
}
