using System;

using Aragas.Core.Extensions;
using Aragas.Core.Wrappers;

using Forge.Enum;

namespace Forge.Packets
{
    public static class ForgeMessages
    {
        public static class HandshakeMessages
        {
            public static readonly Func<PluginMessageSubPacket>[] Packets;

            static HandshakeMessages()
            {
                new ForgeHandshakeMessageTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(ForgeMessages)));
            }
        }

        public static class InternalMessages
        {
            public static readonly Func<PluginMessageSubPacket>[] Packets;

            static InternalMessages()
            {
                new ForgeInternalMessageTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(ForgeMessages)));
            }
        }

        public static class Messages
        {
            public static readonly Func<PluginMessageSubPacket>[] Packets;

            static Messages()
            {
                new ForgeMessageTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(ForgeMessages)));
            }
        }
    }
}
