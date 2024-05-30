using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Char()
    {
        Primitive primitive = new();

        var a = 'A';
        var b = 'Z';

        primitive.Add.Char(a);
        primitive.Add.Char(b);

        Assert.Equal(a, primitive.Get.Char());
        Assert.Equal(b, primitive.Get.Char());
        Assert.True(primitive.IsValid);
    }
}