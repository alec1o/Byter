using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Uint()
    {
        Primitive primitive = new();

        var a = uint.MinValue;
        var b = uint.MaxValue;

        primitive.Add.UInt(a);
        primitive.Add.UInt(b);

        Assert.Equal(a, primitive.Get.UInt());
        Assert.Equal(b, primitive.Get.UInt());
        Assert.True(primitive.IsValid);
    }
}