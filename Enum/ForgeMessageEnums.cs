namespace Forge.Enum
{
    internal enum ForgeHandshakeMessageTypes
    {
        ServerHello                 = 0,
        ClientHello                 = 1,
        ModList                     = 2,
        ModIdData                   = 3,

        HandshakeReset              = 254,
        HandshakeAck                = 255,
    }

    internal enum ForgeInternalMessageTypes
    {
        CompleteHandshake           = 0,
        OpenGui                     = 1,
        EntitySpawn                 = 2,
        EntityAdjust                = 3,
    }

    internal enum ForgeMessageTypes
    {
        DimensionRegister           = 1,
        FluidIdMap                  = 2,
    }
}