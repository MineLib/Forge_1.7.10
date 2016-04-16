using Forge.Enum;
using Forge.Packets;
using Forge.Packets.Client.Forge.Handshake;

namespace Forge.PacketHandlers.Shared.Forge.Handshake
{
    public class ModIdDataHandler : ForgeMessageHandler<ModIdDataPacket, ForgeClientPacketHandlerContext>
    {
        public override PluginMessageSubPacket Handle(ModIdDataPacket packet)
        {

            Context.State = FMLHandshakeClientState.PENDINGCOMPLETE;
            
            return null;
        }
    }
}
