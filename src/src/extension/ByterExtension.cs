using System;
using System.Text;

namespace Byter
{
    internal static class ByterExtension
    {
        public static readonly Encoding DEFAULT_ENCODING = Encoding.UTF8;
        public static readonly byte[] DEFAULT_BYTES_VALUE = Array.Empty<byte>();
        public static readonly string DEFAULT_STRING_VALUE = string.Empty;

        public static bool IsNull(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNull(byte[] value)
        {
            return !(value != null && value.Length > 0);
        }
    }
}