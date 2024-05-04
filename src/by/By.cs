using System;

namespace Byter
{
    public class By : IBy
    {
        public int Index { get; private set; }
        public bool IsValid { get; private set; }
        public byte[] Buffer { get; private set; }

        public void Reset()
        {
            Index = 0;
            IsValid = true;
        }

        public void Add<T>(T value)
        {
            throw new System.NotImplementedException();
        }

        public T Get<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}