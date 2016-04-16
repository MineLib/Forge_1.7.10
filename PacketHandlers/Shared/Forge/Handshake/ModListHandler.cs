using Forge.Enum;
using Forge.Packets;
using Forge.Packets.Client.Forge.Handshake;
using Forge.Packets.Shared.Forge.Handshake;

namespace Forge.PacketHandlers.Shared.Forge.Handshake
{
    public class ModListHandler : ForgeMessageHandler<ModListPacket, ForgeClientPacketHandlerContext>
    {
        public override PluginMessageSubPacket Handle(ModListPacket packet)
        {
            Context.SendForgeMessage(new HandshakeAckPacket { Phase = (byte) FMLHandshakeClientState.WAITINGSERVERDATA} );

            //if (!islocal)
                Context.State = FMLHandshakeClientState.WAITINGSERVERCOMPLETE;
            //else
                //Context.State = FMLHandshakeClientState.PENDINGCOMPLETE;

            return null;
        }
    }
}
