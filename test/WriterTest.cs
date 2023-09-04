using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Xunit;
using Byter;
using Byter.Core;

namespace ByterTest;

public class WriterTest
{
    public WriterTest()
    {

    }

    [Fact]
    public void Write()
    {
        Writer w = new();

        w.Write((byte) 255);
        w.Write((bool) true);
        w.Write((byte[]) new byte[] { 1, 1, 1, 1 });
        w.Write((short) -1024);
        w.Write((ushort) 1024);
        w.Write((int) -2048);
        w.Write((uint) 2048);
        w.Write((long) -4096);
        w.Write((ulong) 4096);
        w.Write((float) 255.255f);
        w.Write((double) 255.255d);
        w.Write((char) 'A');
        w.Write((string) "UTF8");
        w.Write((string) "ASCII", Encoding.ASCII);
        w.Write(new Float2(1, 2));

        byte[] a = w.GetBytes();
        List<byte> b = w.GetList();

        Assert.Equal(a.Length, w.Length);
        Assert.Equal(b.Count, w.Length);
    }
}
