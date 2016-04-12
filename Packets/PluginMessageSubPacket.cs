using System;

using Aragas.Core.IO;
using Aragas.Core.Packets;

namespace Forge.Packets
{
    public abstract class PluginMessageSubPacket : Packet<Byte, PluginMessageSubPacket, ProtobufDataReader, ProtobufStream> { }
}
