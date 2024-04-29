using System.Text;
using Byter;
using Xunit;

namespace ByterTest.extension;

public class ByteExtensionTest
{
    private const string BaseText = "Byter is a bytes serializer!";

    [Fact]
    public void GetString()
    {
        byte[] defBytes = BaseText.GetBytes(StringExtension.Default);
        byte[] utf8Bytes = BaseText.GetBytes(Encoding.UTF8);
        byte[] utf16Bytes = BaseText.GetBytes(Encoding.Unicode);
        byte[] utf32Bytes = BaseText.GetBytes(Encoding.UTF32);

        Assert.Equal(BaseText, defBytes.GetString());
        Assert.Equal(BaseText, utf8Bytes.GetString(Encoding.UTF8));
        Assert.Equal(BaseText, utf16Bytes.GetString(Encoding.Unicode));
        Assert.Equal(BaseText, utf32Bytes.GetString(Encoding.UTF32));
        
        Assert.NotEqual(BaseText, utf16Bytes.GetString(Encoding.UTF8));
        Assert.NotEqual(BaseText, utf32Bytes.GetString(Encoding.Unicode));
        Assert.NotEqual(BaseText, utf8Bytes.GetString(Encoding.UTF32));
    }
}