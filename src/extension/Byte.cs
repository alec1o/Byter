using System.Text;

namespace Byter
{
    public static class ByteExtension
    {
        public static string GetString(this byte[] content)
        {
            if (content == null || content.Length <= 0) return string.Empty;
            return StringExtension.Default.GetString(content);
        }

        public static string GetString(this byte[] content, Encoding encoding)
        {
            if (content == null || content.Length <= 0) return string.Empty;
            return encoding.GetString(content);
        }
    }
}