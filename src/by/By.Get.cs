using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

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

            T value;

            switch (type)
            {
                case Types.Int:
                {
                    if (!IsValidPrefix(type, sizeof(int))) return default;

                    value = (T)(object)BitConverter.ToInt32(Buffer, GetIndex());

                    AddIndex(sizeof(int));

                    return value;
                }
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