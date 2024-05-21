using System.Globalization;
using System.Text;

namespace Byter
{
    public static class StringExtension
    {
        public static Encoding Default { get; set; } = Encoding.UTF8;

        public static byte[] GetBytes(this string content)
        {
            return Default.GetBytes(content);
        }

        public static byte[] GetBytes(this string content, Encoding encoding)
        {
            return encoding.GetBytes(content);
        }

        public static string ToCapitalize(this string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return content;
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(content);
        }

        public static string ToUpperCase(this string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return content;
            return CultureInfo.CurrentCulture.TextInfo.ToUpper(content);
        }

        public static string ToLowerCase(this string content)
        {
            if (string.IsNullOrWhiteSpace(content)) return content;
            return CultureInfo.CurrentCulture.TextInfo.ToLower(content);
        }
    }
}