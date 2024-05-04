using System;

namespace Byter
{
    public partial class By : IBy
    {
        public T Get<T>()
        {
            if (Buffer.Length <= 0 || Index >= Buffer.Length)
            {
                IsValid = false;
                return default;
            }

            Types type = Hash(typeof(T));

            switch (type)
            {
                case Types.Int:
                {
                    if (Index + sizeof(int) + sizeof(sbyte) > _vault.Count) return default;
                    sbyte prefix = (sbyte)_vault[Index];
                    if ((sbyte)type != prefix)
                    {
                        IsValid = false;
                        return default;
                    }

                    int result = BitConverter.ToInt32(Buffer, Index + sizeof(sbyte));
                    Index += sizeof(sbyte) + sizeof(int);
                    return (T)((object)result);
                }


                default:
                    throw new NotImplementedException();
            }
        }
    }
}