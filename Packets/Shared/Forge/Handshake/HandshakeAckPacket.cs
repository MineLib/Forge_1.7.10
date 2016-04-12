using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Shared.Forge.Handshake
{
    public class HandshakeAckPacket : PluginMessageSubPacket
    {
        public byte Phase;


        public override byte ID => (byte) ForgeHandshakeMessageTypes.HandshakeAck;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            Phase = reader.Read(Phase);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(Phase);

            return this;
        }

    }
}