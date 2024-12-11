using System.Globalization;
using System.Text;
using ByEx = Byter.ByterExtension;

namespace Byter
{
    public static class StringExtension
    {
        public static byte[] GetBytes(this string value)
        {
            return ByEx.IsNull(value) ? ByEx.DEFAULT_BYTES_VALUE : ByEx.DEFAULT_ENCODING.GetBytes(value);
        }

        public static byte[] GetBytes(this string value, Encoding encoding)
        {
            return ByEx.IsNull(value) ? ByEx.DEFAULT_BYTES_VALUE : encoding.GetBytes(value);
        }

        public static string ToCapitalize(this string value)
        {
            return ByEx.IsNull(value) ? string.Empty : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value);
        }

        public static string ToUpperCase(this string value)
        {
            return ByEx.IsNull(value) ? string.Empty : CultureInfo.CurrentCulture.TextInfo.ToUpper(value);
        }

        public static string ToLowerCase(this string value)
        {
            return ByEx.IsNull(value) ? string.Empty : CultureInfo.CurrentCulture.TextInfo.ToLower(value);
        }
    }
}