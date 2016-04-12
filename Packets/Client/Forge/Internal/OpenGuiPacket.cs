using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Internal
{
    public class OpenGuiPacket : PluginMessageSubPacket
    {
        public int WindowID;
        public string ModID;
        public int ModGuiID;
        public int X;
        public int Y;
        public int Z;


        public override byte ID => (byte) ForgeInternalMessageTypes.OpenGui;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            WindowID = reader.Read(WindowID);
            ModID = reader.Read(ModID);
            ModGuiID = reader.Read(ModGuiID);
            X = reader.Read(X);
            Y = reader.Read(Y);
            Z = reader.Read(Z);

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(WindowID);
            stream.Write(ModID);
            stream.Write(ModGuiID);
            stream.Write(X);
            stream.Write(Y);
            stream.Write(Z);

            return this;
        }

    }
}