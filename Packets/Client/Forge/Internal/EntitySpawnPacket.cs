using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Internal
{
    public class EntitySpawnPacket : EntityPacket
    {
        public string ModId;
        public int ModEntityTypeId;
        public int RawX;
        public int RawY;
        public int RawZ;
        public double ScaledX;
        public double ScaledY;
        public double ScaledZ;
        public float ScaledYaw;
        public float ScaledPitch;
        public float ScaledHeadYaw;
        public int ThrowerId;
        public double SpeedScaledX;
        public double SpeedScaledY;
        public double SpeedScaledZ;
        //List dataWatcherList;
        //ByteBuf dataStream;


        public override byte ID => (byte) ForgeInternalMessageTypes.EntitySpawn;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            base.ReadPacket(reader);
            ModId = reader.Read(ModId);
            ModEntityTypeId = reader.Read(ModEntityTypeId);
            RawX = reader.Read(RawX);
            RawY = reader.Read(RawY);
            RawZ = reader.Read(RawZ);
            ScaledX = RawX / 32.0;
            ScaledY = RawY / 32.0;
            ScaledZ = RawZ / 32.0;
            ScaledYaw = reader.Read<byte>() * 360.0f / 256.0f;
            ScaledPitch = reader.Read<byte>() * 360.0f / 256.0f;
            ScaledHeadYaw = reader.Read<byte>() * 360.0f / 256.0f;
            ThrowerId = reader.Read(ThrowerId);
            if (ThrowerId != 0)
            {
                SpeedScaledX = reader.Read<int>() / 8000.0;
                SpeedScaledY = reader.Read<int>() / 8000.0;
                SpeedScaledZ = reader.Read<int>() / 8000.0;
            }

            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            base.WritePacket(stream);
            stream.Write(ModId);
            stream.Write(ModEntityTypeId);
            RawX = (int) (ScaledX * 32.0);
            RawX = (int) (ScaledY * 32.0);
            RawX = (int) (ScaledZ * 32.0);
            stream.Write(RawX);
            stream.Write(RawY);
            stream.Write(RawZ);
            stream.Write((byte) (ScaledYaw / 360.0f * 256.0f));
            stream.Write((byte) (ScaledPitch / 360.0f * 256.0f));
            stream.Write((byte) (ScaledHeadYaw / 360.0f * 256.0f));
            stream.Write(ThrowerId);
            if (ThrowerId != 0)
            {
                stream.Write((int) (SpeedScaledX * 8000.0));
                stream.Write((int) (SpeedScaledY * 8000.0));
                stream.Write((int) (SpeedScaledZ * 8000.0));
            }

            return this;
        }

    }
}