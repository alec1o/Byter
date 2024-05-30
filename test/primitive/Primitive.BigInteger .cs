using System.Numerics;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _BigInteger()
    {
        Primitive primitive = new();

        var a = BigInteger.Parse("48379248907234576538726734523908487382645789326579326573876265734675564333");
        var b = BigInteger.Parse("38957284567382657578437865398748543908564376473947560232934732894732467883");

        primitive.Add.BigInteger(a);
        primitive.Add.BigInteger(b);

        Assert.Equal(a, primitive.Get.BigInteger());
        Assert.Equal(b, primitive.Get.BigInteger());
        Assert.True(primitive.IsValid);
    }
}