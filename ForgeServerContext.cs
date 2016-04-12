using Aragas.Core.PacketHandlers;

using Forge.Enum;

namespace Forge
{
    public class ForgeServerContext : IPacketHandlerContext
    {
        public FMLHandshakeServerState State { get; set; }
        public int ProtocolVersion { get; set; }


        public ForgeServerContext() { }
    }
}