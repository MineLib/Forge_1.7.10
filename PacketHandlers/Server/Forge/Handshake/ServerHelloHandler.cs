using System.Linq;
using System.Text;

using Forge.Enum;
using Forge.Packets;
using Forge.Packets.Client.Forge.Handshake;
using Forge.Packets.Server.Forge.Handshake;

using ProtocolModern.Data;

namespace Forge.PacketHandlers.Server.Forge.Handshake
{
    public class ServerHelloHandler : ForgeMessageHandler<ServerHelloPacket, ForgeClientPacketHandlerContext>
    {
        public override PluginMessageSubPacket Handle(ServerHelloPacket packet)
        {
            var forgeInfo = new ForgeModInfo();
            var response = (ServerResponse) Context.ServerInfo.ServerResponse;
            if (response.Info.ModInfo != null)
                forgeInfo = response.Info.ModInfo.Value;


            string[] channels = { "FML|HS", "FML", "FML|MP", "FML", "FORGE" };
            Context.SendPluginMessage("REGISTER", Encoding.UTF8.GetBytes(string.Join("\0", channels)));

            Context.Version = packet.ProtocolVersion;

            Context.SendForgeMessage(new ClientHelloPacket
            {
                ProtocolVersion = (byte) Context.Version
            });
            Context.SendForgeMessage(new ModListPacket
            {
                Mods = forgeInfo.Mods.Select(mod => new ModListPacket.Mod { ModName = mod.ModID, ModVersion = mod.Version }).ToList()
            });

            Context.State = FMLHandshakeClientState.WAITINGSERVERDATA;
            
            return null;
        }
    }
}
