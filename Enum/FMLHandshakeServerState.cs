namespace Forge.Enum
{
    public enum FMLHandshakeServerState : byte
    {
        START,
        HELLO,
        WAITINGCACK,
        COMPLETE,
        DONE,
        ERROR
    }
}