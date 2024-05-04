namespace Byter
{
    public partial class By : IBy
    {
        public void Reset()
        {
            Index = 0;
            IsValid = true;
        }
    }
}