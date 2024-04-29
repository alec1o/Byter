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
    }
}