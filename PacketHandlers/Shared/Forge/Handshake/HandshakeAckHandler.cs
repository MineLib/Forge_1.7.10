using Forge.Enum;
using Forge.Packets;
using Forge.Packets.Shared.Forge.Handshake;

namespace Forge.PacketHandlers.Shared.Forge.Handshake
{
    public class HandshakeAckHandler : ForgeMessageHandler<HandshakeAckPacket, ForgeClientPacketHandlerContext>
    {
        public override PluginMessageSubPacket Handle(HandshakeAckPacket packet)
        {
            switch (Context.State)
            {
                case FMLHandshakeClientState.PENDINGCOMPLETE:
                    Context.SendForgeMessage(new HandshakeAckPacket { Phase = (byte) FMLHandshakeClientState.PENDINGCOMPLETE });
                    Context.State = FMLHandshakeClientState.COMPLETE;
                    break;

                case FMLHandshakeClientState.COMPLETE:
                    Context.SendForgeMessage(new HandshakeAckPacket { Phase = (byte) FMLHandshakeClientState.COMPLETE });
                    Context.State = FMLHandshakeClientState.DONE;
                    break;
            }

            return null;
        }
    }
}
