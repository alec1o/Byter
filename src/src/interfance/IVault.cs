namespace Byter
{
    public interface IVault
    {
        bool IsValid { get; }
        byte[] Data { get; }
        IVaultAdd Add { get; }
        IVaultGet Get { get; }
    }
}