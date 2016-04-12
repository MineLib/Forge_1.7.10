using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge
{
    public class DimensionRegisterPacket : PluginMessageSubPacket
    {
        public int DimensionID;
        public int ProviderID;
        

        public override byte ID => (byte) ForgeMessageTypes.DimensionRegister;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            DimensionID = reader.Read(DimensionID);
            ProviderID = reader.Read(ProviderID);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(DimensionID);
            stream.Write(ProviderID);

            return this;
        }

    }
}