using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Byte()
    {
        Primitive primitive = new();

        var a = byte.MinValue;
        var b = byte.MaxValue;

        primitive.Add.Byte(a);
        primitive.Add.Byte(b);

        Assert.Equal(a, primitive.Get.Byte());
        Assert.Equal(b, primitive.Get.Byte());
        Assert.True(primitive.IsValid);
    }
}