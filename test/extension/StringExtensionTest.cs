using System;
using System.Text;
using Byter;
using Xunit;

namespace ByterTest.extension;

public class StringExtensionTest
{
    private const string BaseText /**/ = "Byter is a bytes serializer!";
    private const string BaseTextUpper = "BYTER IS A BYTES SERIALIZER!";
    private const string BaseTextLower = "byter is a bytes serializer!";
    private const string BaseTextCaptz = "Byter Is A Bytes Serializer!";

    [Fact]
    public void GetBytes()
    {
        byte[] dotnetUtf8 = Encoding.UTF8.GetBytes(BaseText);
        byte[] dotnetUtf16 = Encoding.Unicode.GetBytes(BaseText);
        byte[] dotnetUtf32 = Encoding.UTF32.GetBytes(BaseText);

        Assert.Equal(dotnetUtf8, BaseText.GetBytes(Encoding.UTF8));
        Assert.Equal(dotnetUtf16, BaseText.GetBytes(Encoding.Unicode));
        Assert.Equal(dotnetUtf32, BaseText.GetBytes(Encoding.UTF32));
    }

    [Fact]
    public void GetBytesDefault()
    {
        var utf8Encoded = Encoding.UTF8.GetBytes(BaseText);
        var utf32Encoded = Encoding.UTF32.GetBytes(BaseText);
        var defaultEncoded = BaseText.GetBytes();

        {
            Assert.Equal(utf8Encoded, defaultEncoded);
            Assert.NotEqual(utf8Encoded, utf32Encoded);
            Assert.NotEqual(utf32Encoded, defaultEncoded);
            Assert.Equal(utf8Encoded.GetString(Encoding.UTF8), defaultEncoded.GetString());
            Assert.Equal(utf8Encoded.GetString(Encoding.UTF8), utf32Encoded.GetString(Encoding.UTF32));
            Assert.NotEqual(defaultEncoded.GetString(), utf32Encoded.GetString()); // need add Encoding.UTF32
            Assert.NotEqual(utf8Encoded.GetString(), utf32Encoded.GetString()); // need add Encoding.UTF32
            Assert.Equal(defaultEncoded.GetString(), utf32Encoded.GetString(Encoding.UTF32)); // Now is OKAY!
            Assert.Equal(utf8Encoded.GetString(), utf32Encoded.GetString(Encoding.UTF32)); // Now is OKAY!
        }
    }

    [Fact]
    public void TestText()
    {
        Assert.Equal(BaseTextLower, BaseText.ToLower());
        Assert.Equal(BaseTextUpper, BaseText.ToUpper());

        Assert.NotEqual(BaseText, BaseText.ToLower());
        Assert.NotEqual(BaseText, BaseText.ToUpper());

        Assert.NotEqual(BaseTextCaptz, BaseText.ToLower());
        Assert.NotEqual(BaseTextCaptz, BaseText.ToUpper());
    }

    [Fact]
    public void ToLowerCase()
    {
        Assert.NotEqual(BaseTextLower, BaseText);
        Assert.Equal(BaseTextLower, BaseText.ToLowerCase());
    }

    [Fact]
    public void ToUpperCase()
    {
        Assert.NotEqual(BaseTextUpper, BaseText);
        Assert.Equal(BaseTextUpper, BaseText.ToUpperCase());
    }

    [Fact]
    public void ToCapitalizeCase()
    {
        Assert.NotEqual(BaseTextCaptz, BaseText);
        Assert.Equal(BaseTextCaptz, BaseText.ToCapitalize());
    }

    [Fact]
    public void Nullable()
    {
        var result = Array.Empty<byte>();
        Assert.Equal(result, string.Empty.GetBytes());
        Assert.Equal(result, StringExtension.GetBytes(null!));
    }
}