using System;
using Xunit;
using Byter;

namespace ByterTest;

public class ReaderTest
{
    [Fact]
    public void Read()
    {
        Writer w = new();
        WriterTest.Load(ref w);
        Reader r = new(ref w);

        string name = r.Read<string>();     // Name  : Byter Library
        byte old = r.Read<byte>();          // Old   : 1
        int star = r.Read<int>();           // Start : 2048
        long id = r.Read<long>();           // Id    : 1024
        byte[] pdf = r.Read<byte[]>();      // Pdf   : [ 1, 1, 1, 1 ]

        Assert.Equal("Byter Library", name);
        Assert.Equal((byte)1, old);
        Assert.Equal((int)2048, star);
        Assert.Equal((long)1024, id);
        Assert.Equal(new byte[]{ 1, 1, 1, 1 }, pdf);
    }
}