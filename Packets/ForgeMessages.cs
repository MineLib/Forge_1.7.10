using System;

using Aragas.Core.Extensions;
using Aragas.Core.Wrappers;

using Forge.Enum;

namespace Forge.Packets
{
    internal static class ForgeMessages
    {
        internal static class HandshakeMessages
        {
            internal static readonly Func<PluginMessageSubPacket>[] Packets;

            static HandshakeMessages()
            {
                new ForgeHandshakeMessageTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(ForgeMessages)));
            }
        }

        internal static class InternalMessages
        {
            internal static readonly Func<PluginMessageSubPacket>[] Packets;

            static InternalMessages()
            {
                new ForgeInternalMessageTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(ForgeMessages)));
            }
        }

        internal static class Messages
        {
            internal static readonly Func<PluginMessageSubPacket>[] Packets;

            static Messages()
            {
                new ForgeMessageTypes().CreatePacketInstancesOut(out Packets, AppDomainWrapper.GetAssembly(typeof(ForgeMessages)));
            }
        }
    }
}
