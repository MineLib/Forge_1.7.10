using System.Collections.Generic;

using Aragas.Core.IO;
using Aragas.Core.Packets;

using Forge.Enum;
using Forge.PacketHandlers;
using Forge.Packets;

using MineLib.Core;
using MineLib.Core.Client;

using ProtocolModern.Packets.Client.Play;
using ProtocolModern.Packets.Server.Play;


namespace Forge
{
    public class ForgeClientPacketHandlerContext : IForgePacketHandlerContext
    {
        public FMLHandshakeClientState State { get; set; }

        public int Version { get; set; }

        public ServerInfo ServerInfo { get; }

        private IModAPIContext ModContext { get; }


        public ForgeClientPacketHandlerContext(ServerInfo serverInfo, IModAPIContext context) { ServerInfo = serverInfo; ModContext = context; }


        public void HandlePacket(ProtobufPacket packet)
        {
            var pluginMessage = packet as PluginMessagePacket;
            if (pluginMessage != null)
                OnPluginChannelMessage(pluginMessage.Channel, pluginMessage.Data);
        }
        
        private bool OnPluginChannelMessage(string channel, byte[] data)
        {
            if (channel == "FML|HS")
            {
                using (var reader = new ProtobufDataReader(data))
                {
                    var discriminator = reader.Read<byte>();
                    var message = ForgeMessages.HandshakeMessages.Packets[discriminator]().ReadPacket(reader);

                    var handler = ForgeMessageHandlers.HandshakeMessageHandlers.Handlers[discriminator]?.Invoke(this);
                    SendForgeMessage(handler?.Handle(message));
                }
                return true;
            }

            if (channel == "FML")
            {
                using (var reader = new ProtobufDataReader(data))
                {
                    var discriminator = reader.Read<byte>();
                    var message = ForgeMessages.InternalMessages.Packets[discriminator]().ReadPacket(reader);

                    var handler = ForgeMessageHandlers.InternalMessageHandlers.Handlers[discriminator]?.Invoke(this);
                    SendForgeMessage(handler?.Handle(message));
                }
                return true;
            }

            if (channel == "FORGE")
            {
                using (var reader = new ProtobufDataReader(data))
                {
                    var discriminator = reader.Read<byte>();
                    var message = ForgeMessages.Messages.Packets[discriminator]().ReadPacket(reader);

                    var handler = ForgeMessageHandlers.MessageHandlers.Handlers[discriminator]?.Invoke(this);
                    SendForgeMessage(handler?.Handle(message));
                }
                return true;
            }

            return false;
        }

        public void SendPluginMessage(string channel, byte[] data)
        {
            ModContext.SendPacket(new PluginMessage2Packet { Channel = channel, Data = data });
        }

        public void SendForgeMessage(PluginMessageSubPacket message)
        {
            if (message == null)
                return;

            using (var writer = new ProtobufStream(null))
            {
                message.WritePacket(writer);
                SendPluginMessage("FML|HS", Combine(new[] { message.ID }, writer.GetBuffer()));
            }
        }
        private static byte[] Combine(params byte[][] bytes)
        {
            var result = new List<byte>();
            foreach (var array in bytes)
                result.AddRange(array);
            return result.ToArray();
        }
    }
}