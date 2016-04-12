using System.Collections.Generic;
using System.Linq;

using Aragas.Core.Data;
using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Handshake
{
    public class ModIdDataPacket : PluginMessageSubPacket
    {
        public struct BlockID
        {
            public string Name;
            public VarInt ID;
        }


        public List<BlockID> Mapping = new List<BlockID>();
        private List<string> BlockSubstitutions = new List<string>();
        private List<string> ItemSubstitutions = new List<string>();


        public override byte ID => (byte) ForgeHandshakeMessageTypes.ModIdData;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            if (reader.BytesLeft() <= 1)
                return this;

            var length = reader.Read<VarInt>();
            for (var i = 0; i < length; i++)
                Mapping.Add(new BlockID
                {
                    Name = reader.Read<string>(),
                    ID = reader.Read<VarInt>()
                });
            

            if (reader.BytesLeft() > 1)
            {
                length = reader.Read<VarInt>();
                for (var i = 0; i < length; i++)
                    BlockSubstitutions.Add(reader.Read<string>());

                length = reader.Read<VarInt>();
                for (var i = 0; i < length; i++)
                    ItemSubstitutions.Add(reader.Read<string>());
            }

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Mapping.Count);
            foreach (var blockID in Mapping)
            {
                stream.Write(blockID.Name);
                stream.Write(blockID.ID);
            }

            if (BlockSubstitutions.Any())
            {
                stream.Write(BlockSubstitutions.Count);
                foreach (var blockSubstitution in BlockSubstitutions)
                    stream.Write(blockSubstitution);
                
                stream.Write(ItemSubstitutions.Count);
                foreach (var itemSubstitution in ItemSubstitutions)
                    stream.Write(itemSubstitution);
            }

            return this;
        }

    }
}