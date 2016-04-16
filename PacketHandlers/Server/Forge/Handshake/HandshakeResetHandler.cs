using Forge.Enum;
using Forge.Packets;
using Forge.Packets.Client.Forge.Handshake;

namespace Forge.PacketHandlers.Server.Forge.Handshake
{
    public class HandshakeResetHandler : ForgeMessageHandler<HandshakeResetPacket, ForgeClientPacketHandlerContext>
    {
        public override PluginMessageSubPacket Handle(HandshakeResetPacket packet)
        {
            Context.State = FMLHandshakeClientState.HELLO;

            return null;
        }
    }
}
