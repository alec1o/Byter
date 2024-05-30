using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Sbyte()
    {
        Primitive primitive = new();

        var a = sbyte.MinValue;
        var b = sbyte.MaxValue;

        primitive.Add.SByte(a);
        primitive.Add.SByte(b);

        Assert.Equal(a, primitive.Get.SByte());
        Assert.Equal(b, primitive.Get.SByte());
        Assert.True(primitive.IsValid);
    }
}