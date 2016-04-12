using Aragas.Core.IO;

namespace Forge.Packets.Client.Forge.Internal
{
    public class EntityPacket : PluginMessageSubPacket
    {
        public int EntityID;


        public override byte ID => 255;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            EntityID = reader.Read(EntityID);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(EntityID);

            return this;
        }

    }
}