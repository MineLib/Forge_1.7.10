using Aragas.Core.Packets;

using Forge.PacketHandlers;

using MineLib.Core;
using MineLib.Core.Client;

namespace Forge
{
    public class ForgeModAPI : ModAPI
    {
        private IForgePacketHandlerContext ForgeHandlerContext { get; set; }


        public ForgeModAPI(ModAPISide side, IModAPIContext context) : base(side, context) { }


        public override void OnConnect(ServerInfo serverInfo)
        {
            switch (Side)
            {
                case ModAPISide.Client:
                    ForgeHandlerContext = new ForgeClientPacketHandlerContext(serverInfo, Context);
                    break;

                case ModAPISide.Server:
                    ForgeHandlerContext = new ForgeServerPacketHandlerContext(Context);
                    break;
            }
        }

        public override void OnPacket(ProtobufPacket packet) { ForgeHandlerContext.HandlePacket(packet); }
    }
}