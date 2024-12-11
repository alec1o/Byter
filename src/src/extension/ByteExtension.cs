using System.Collections.Generic;
using System.Linq;
using System.Text;
using ByEx = Byter.ByterExtension;

namespace Byter
{
    public static class ByteExtension
    {
        public static string GetString(this byte[] content)
        {
            return ByEx.IsNull(content) ? ByEx.DEFAULT_STRING_VALUE : ByEx.DEFAULT_ENCODING.GetString(content);
        }

        public static string GetString(this byte[] content, Encoding encoding)
        {
            return ByEx.IsNull(content) ? ByEx.DEFAULT_STRING_VALUE : encoding.GetString(content);
        }

        public static byte[] Concat(this byte[] value, params byte[][] values)
        {
            return Concat(value, false, values);
        }
        
        public static byte[] ConcatInverse(this byte[] value, params byte[][] values)
        {
            return Concat(value, true, values);
        }

        public static byte[] Concat(this byte[] value, bool invert, params byte[][] values)
        {
            var list = new List<byte[]> { value };

            list.AddRange(values);

            if (!invert || list.Count <= 1) return list.SelectMany(x => x).ToArray();

            var reversed = new List<byte[]>();

            var count = list.Count - 1;

            while (list.Count > 0)
            {
                reversed.Add(list[count]);
                list.RemoveAt(count);
                count--;
            }

            list.Clear();

            return reversed.SelectMany(x => x).ToArray();
        }
    }
}