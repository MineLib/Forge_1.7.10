using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Internal
{
    public class CompleteHandshakePacket : PluginMessageSubPacket
    {
        public byte Target;


        public override byte ID => (byte) ForgeInternalMessageTypes.CompleteHandshake;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            Target = reader.Read(Target);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Target);

            return this;
        }

    }
}