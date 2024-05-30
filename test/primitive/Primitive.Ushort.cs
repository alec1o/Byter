using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Ushort()
    {
        Primitive primitive = new();

        var a = ushort.MinValue;
        var b = ushort.MaxValue;

        primitive.Add.UShort(a);
        primitive.Add.UShort(b);

        Assert.Equal(a, primitive.Get.UShort());
        Assert.Equal(b, primitive.Get.UShort());
        Assert.True(primitive.IsValid);
    }
}