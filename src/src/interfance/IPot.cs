namespace Byter
{
    public interface IPot
    {
        bool IsValid { get; }
        byte[] Data { get; }
        IVaultAdd Add { get; }
        IVaultGet Get { get; }
    }
}