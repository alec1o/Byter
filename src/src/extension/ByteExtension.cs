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
    }
}