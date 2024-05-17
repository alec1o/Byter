namespace Byter
{
    public interface IPot
    {
        bool IsValid { get; }
        byte[] Data { get; }
        IPotAdd Add { get; }
        IPotGet Get { get; }
    }
}