namespace Byter
{
    internal interface IPrimitive
    {
        int Position { get; }
        bool IsValid { get; }
        byte[] Data { get; }
        IPrimitiveAdd Add { get; }
        IPrimitiveGet Get { get; }
        void Reset(byte[] data = null);
    }
}