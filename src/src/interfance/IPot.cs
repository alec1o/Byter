namespace Byter
{
    public interface IPot
    {
        bool IsValid { get; }
        int Count { get; }
        byte[] Data { get; }
        IAdd Add { get; }
        IGet Get { get; }
    }
}