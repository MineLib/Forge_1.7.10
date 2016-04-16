using Aragas.Core.Packets;

using Forge.Enum;
using Forge.PacketHandlers;

using MineLib.Core;

namespace Forge
{
    public class ForgeServerPacketHandlerContext : IForgePacketHandlerContext
    {
        public FMLHandshakeServerState State { get; set; }
        public int Version { get; set; }


        private IModAPIContext Context { get; }


        public ForgeServerPacketHandlerContext(IModAPIContext context) { Context = context; }


        public void HandlePacket(ProtobufPacket packet) { }
    }
}