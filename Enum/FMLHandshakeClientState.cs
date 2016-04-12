namespace Forge.Enum
{
    public enum FMLHandshakeClientState : byte
    {
        START,
        HELLO,
        WAITINGSERVERDATA,
        WAITINGSERVERCOMPLETE,
        PENDINGCOMPLETE,
        COMPLETE,
        DONE,
        ERROR
    }
}