using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Server.Forge.Handshake
{
    public class ClientHelloPacket : PluginMessageSubPacket
    {
        public byte ProtocolVersion;


        public override byte ID => (byte) ForgeHandshakeMessageTypes.ClientHello;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            ProtocolVersion = reader.Read(ProtocolVersion);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(ProtocolVersion);

            return this;
        }

    }
}