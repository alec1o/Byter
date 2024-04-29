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
        Encoding defaultEncoding = Encoding.UTF8;
        byte[] defaultEncodingResult = defaultEncoding.GetBytes(BaseText);
        byte[] internalDefaultEncodingResult = BaseText.GetBytes();

        Assert.Equal(defaultEncoding, StringExtension.Default);
        Assert.Equal(defaultEncodingResult, internalDefaultEncodingResult);

        Encoding newEncoding = Encoding.UTF32;
        StringExtension.Default = newEncoding;
        byte[] newEncodingResult = newEncoding.GetBytes(BaseText);
        byte[] internalNewEncodingResult = BaseText.GetBytes();

        Assert.NotEqual(defaultEncodingResult, internalNewEncodingResult);
        Assert.Equal(newEncodingResult, internalNewEncodingResult);
    }

    [Fact]
    public void TestText()
    {
        Assert.Equal(BaseText.ToLower(), BaseTextLower);
        Assert.Equal(BaseText.ToUpper(), BaseTextUpper);

        Assert.NotEqual(BaseText.ToLower(), BaseText);
        Assert.NotEqual(BaseText.ToUpper(), BaseText);

        Assert.NotEqual(BaseText.ToLower(), BaseTextCaptz);
        Assert.NotEqual(BaseText.ToUpper(), BaseTextCaptz);
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
}