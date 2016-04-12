using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Internal
{
    public class EntityAdjustPacket : EntityPacket
    {
        public int ServerX;
        public int ServerY;
        public int ServerZ;


        public override byte ID => (byte) ForgeInternalMessageTypes.EntityAdjust;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            base.ReadPacket(reader);
            ServerX = reader.Read(ServerX);
            ServerY = reader.Read(ServerY);
            ServerZ = reader.Read(ServerZ);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            base.WritePacket(stream);
            stream.Write(ServerX);
            stream.Write(ServerY);
            stream.Write(ServerZ);

            return this;
        }

    }
}