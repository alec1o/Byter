using System;
using Xunit;
using Byter;

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
        Load(ref w);
    }

    public static void Load(ref Writer w)
    {
       w.Write((string) "Byter Library");   // e.g. Name
        w.Write((byte) 1);                  // e.g. Old
        w.Write((int) 2048);                // e.g. Start
        w.Write((long) 1024);               // e.g. Id
        w.Write(new byte[]{ 1, 1, 1, 1 });  // e.g. Pdf
    }

}