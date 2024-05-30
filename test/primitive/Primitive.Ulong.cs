using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Ulong()
    {
        Primitive primitive = new();

        var a = ulong.MinValue;
        var b = ulong.MaxValue;

        primitive.Add.ULong(a);
        primitive.Add.ULong(b);

        Assert.Equal(a, primitive.Get.ULong());
        Assert.Equal(b, primitive.Get.ULong());
        Assert.True(primitive.IsValid);
    }
}