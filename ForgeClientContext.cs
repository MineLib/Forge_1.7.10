using System;

using Aragas.Core.PacketHandlers;

using Forge.Enum;
using Forge.Packets;

using MineLib.Core.Interfaces;

namespace Forge
{
    public class ForgeClientContext : IPacketHandlerContext
    {
        public FMLHandshakeClientState State { get; set; }
        public int ProtocolVersion { get; set; }

        public IServerInfo ServerInfo { get; }

        private readonly Action<string, byte[]> _sendPluginMessage;
        private readonly Action<PluginMessageSubPacket> _sendForgeMessage;


        public ForgeClientContext(IServerInfo serverInfo, Action<string, byte[]> sendPluginMessage, Action<PluginMessageSubPacket> sendForgeMessage)
        {
            ServerInfo = serverInfo;
            _sendPluginMessage = sendPluginMessage;
            _sendForgeMessage = sendForgeMessage;

            if(_sendPluginMessage == null)
                throw new ArgumentNullException(nameof(_sendPluginMessage));
            if(_sendForgeMessage == null)
                throw new ArgumentNullException(nameof(_sendForgeMessage));
        }


        public void SendPluginMessage(string channel, byte[] data) { _sendPluginMessage(channel, data); }
        public void SendForgeMessage(PluginMessageSubPacket message) { _sendForgeMessage(message); }
    }
}