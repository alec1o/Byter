using System;
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
        var utf8Bytes = BaseText.GetBytes(Encoding.UTF8);
        var utf16Bytes = BaseText.GetBytes(Encoding.Unicode);
        var utf32Bytes = BaseText.GetBytes(Encoding.UTF32);

        Assert.Equal(BaseText, utf8Bytes.GetString(Encoding.UTF8));
        Assert.Equal(BaseText, utf16Bytes.GetString(Encoding.Unicode));
        Assert.Equal(BaseText, utf32Bytes.GetString(Encoding.UTF32));

        Assert.NotEqual(BaseText, utf16Bytes.GetString(Encoding.UTF8));
        Assert.NotEqual(BaseText, utf32Bytes.GetString(Encoding.Unicode));
        Assert.NotEqual(BaseText, utf8Bytes.GetString(Encoding.UTF32));
    }

    [Fact]
    public void Nullable()
    {
        var result = string.Empty;
        Assert.Equal(result, Array.Empty<byte>().GetString());
        Assert.Equal(result, ByteExtension.GetString(null!));
    }

    [Fact]
    public void Concat()
    {
        byte[] part1 = [1, 2, 3];
        byte[] part2 = [4, 5, 6];
        byte[] part3 = [7, 8, 9];

        Assert.Equal([1, 2, 3, /**/ 4, 5, 6], part1.Concat(part2));
        Assert.Equal([1, 2, 3, /**/ 4, 5, 6], part1.Concat(false, part2));
        Assert.Equal([1, 2, 3, /**/ 4, 5, 6, /**/7, 8, 9], part1.Concat(false, part2, part3));

        Assert.Equal([4, 5, 6, /**/ 1, 2, 3], part1.ConcatInverse(part2));
        Assert.Equal([4, 5, 6, /**/ 1, 2, 3], part1.Concat(true, part2));
        Assert.Equal([7, 8, 9, /**/ 4, 5, 6, /**/ 1, 2, 3,], part1.Concat(true, part2, part3));
    }
}