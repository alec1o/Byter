namespace Byter
{
    public interface IPrimitive
    {
        bool IsValid { get; }
        byte[] Data { get; }
        IPrimitiveAdd Add { get; }
        IPrimitiveGet Get { get; }
    }
}