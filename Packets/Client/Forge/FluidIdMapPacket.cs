using System.Collections.Generic;
using System.Linq;

using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge
{
    public class FluidIdMapPacket : PluginMessageSubPacket
    {
        public struct FluidIDMap
        {
            public string Name;
            public int ID;
        }

        public List<FluidIDMap> FluidIDs = new List<FluidIDMap>();
        public List<string> DefaultFluids = new List<string>();


        public override byte ID => (byte) ForgeMessageTypes.FluidIdMap;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            var FluidIDsLength = reader.Read<int>();
            for (var i = 0; i < FluidIDsLength; i++)
                FluidIDs.Add(new FluidIDMap
                {
                    Name = reader.Read<string>(),
                    ID = reader.Read<int>()
                });

            if (reader.BytesLeft() > 0)
            {
                for (var i = 0; i < FluidIDsLength; i++)
                    DefaultFluids.Add(reader.Read<string>());
            }

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(FluidIDs.Count);
            foreach (var fluidIDMap in FluidIDs)
            {
                stream.Write(fluidIDMap.Name);
                stream.Write(fluidIDMap.ID);
            }

            if (DefaultFluids.Any())
                foreach (var defaultFluid in DefaultFluids)
                    stream.Write(defaultFluid);
             
            return this;
        }

    }
}