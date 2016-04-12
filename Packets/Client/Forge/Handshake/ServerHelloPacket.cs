using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Handshake
{
    public class ServerHelloPacket : PluginMessageSubPacket
    {
        public byte ProtocolVersion;
        public int? OverrideDimension;


        public override byte ID => (byte) ForgeHandshakeMessageTypes.ServerHello;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            ProtocolVersion = reader.Read(ProtocolVersion);
            if (ProtocolVersion > 1)
                OverrideDimension = reader.Read<int>();

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(ProtocolVersion);
            if(OverrideDimension != null)
                stream.Write(OverrideDimension);

            return this;
        }

    }
}