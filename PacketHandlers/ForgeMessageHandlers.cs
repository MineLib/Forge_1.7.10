using System;

using Aragas.Core.Extensions;
using Aragas.Core.PacketHandlers;
using Aragas.Core.Wrappers;

using Forge.Enum;
using Forge.Packets;

namespace Forge.PacketHandlers
{
    internal static class ForgeMessageHandlers
    {
        internal static class HandshakeMessageHandlers
        {
            internal static readonly Func<IPacketHandlerContext, ContextFunc<PluginMessageSubPacket>>[] Handlers;

            static HandshakeMessageHandlers()
            {
                new ForgeHandshakeMessageTypes().CreateHandlerInstancesOut(out Handlers, AppDomainWrapper.GetAssembly(typeof(ForgeMessageHandlers)));
            }
        }

        internal static class InternalMessageHandlers
        {
            internal static readonly Func<IPacketHandlerContext, ContextFunc<PluginMessageSubPacket>>[] Handlers;

            static InternalMessageHandlers()
            {
                new ForgeInternalMessageTypes().CreateHandlerInstancesOut(out Handlers, AppDomainWrapper.GetAssembly(typeof(ForgeMessageHandlers)));
            }
        }

        internal static class MessageHandlers
        {
            internal static readonly Func<IPacketHandlerContext, ContextFunc<PluginMessageSubPacket>>[] Handlers;

            static MessageHandlers()
            {
                new ForgeMessageTypes().CreateHandlerInstancesOut(out Handlers, AppDomainWrapper.GetAssembly(typeof(ForgeMessageHandlers)));
            }
        }
    }
}
