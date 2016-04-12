using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Handshake
{
    public class HandshakeResetPacket : PluginMessageSubPacket
    {
        public override byte ID => (byte) ForgeHandshakeMessageTypes.HandshakeReset;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            return this;
        }

    }
}