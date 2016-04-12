using System.Collections.Generic;

using Aragas.Core.Data;
using Aragas.Core.IO;

using Forge.Enum;

namespace Forge.Packets.Client.Forge.Handshake
{
    public class ModListPacket : PluginMessageSubPacket
    {
        public struct Mod
        {
            public string ModName { get; set; }
            public string ModVersion { get; set; }
        }


        public List<Mod> Mods = new List<Mod>();


        public override byte ID => (byte) ForgeHandshakeMessageTypes.ModList;

        public override PluginMessageSubPacket ReadPacket(ProtobufDataReader reader)
        {
            var ModsLength = reader.Read<VarInt>();
            for (var i = 0; i < ModsLength; i++)
                Mods.Add(new Mod
                {
                    ModName = reader.Read<string>(),
                    ModVersion = reader.Read<string>()
                });
            
            return this;
        }

        public override PluginMessageSubPacket WritePacket(ProtobufStream stream)
        {
            stream.Write(new VarInt(Mods.Count));
            foreach (var mod in Mods)
            {
                stream.Write(mod.ModName);
                stream.Write(mod.ModVersion);
            }

            return this;
        }

    }
}