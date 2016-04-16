using Aragas.Core.PacketHandlers;

using Forge.Packets;

namespace Forge.PacketHandlers
{
    public abstract class ForgeMessageHandler<TRequestPacket, TForgeContext> :
        PacketHandler<TRequestPacket, PluginMessageSubPacket, TForgeContext> where TRequestPacket : PluginMessageSubPacket where TForgeContext : IForgePacketHandlerContext
    { }
}