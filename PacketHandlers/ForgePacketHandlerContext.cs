using Aragas.Core.PacketHandlers;
using Aragas.Core.Packets;

namespace Forge.PacketHandlers
{
    public interface IForgePacketHandlerContext : IPacketHandlerContext
    {
        void HandlePacket(ProtobufPacket packet);
    }
}