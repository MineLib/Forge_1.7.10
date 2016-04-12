namespace Forge.Enum
{
    public enum ForgeHandshakeMessageTypes
    {
        ServerHello                 = 0,
        ClientHello                 = 1,
        ModList                     = 2,
        ModIdData                   = 3,

        HandshakeReset              = 254,
        HandshakeAck                = 255,
    }

    public enum ForgeInternalMessageTypes
    {
        CompleteHandshake           = 0,
        OpenGui                     = 1,
        EntitySpawn                 = 2,
        EntityAdjust                = 3,
    }

    public enum ForgeMessageTypes
    {
        DimensionRegister           = 1,
        FluidIdMap                  = 2,
    }
}