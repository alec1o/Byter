using System;
using System.Collections.Generic;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _List()
    {
        _List1();
        _List2();
        _List3();
    }

    private void _List1()
    {
        Primitive primitive = new();

        var list = new List<string>
        {
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
            Guid.NewGuid().ToString(),
        };

        primitive.Add.List(list);

        Assert.Equal(list, primitive.Get.List<string>());
        Assert.True(primitive.IsValid);
    }

    private void _List2()
    {
        Primitive primitive = new();

        var list = new List<List<string>>
        {
            new()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            },
            new()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            },
            new()
            {
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
            },
        };

        primitive.Add.List(list);

        var myList = primitive.Get.List<List<string>>();
        Assert.Equal(list, myList);
        for (int i = 0; i < list.Count; i++)
        {
            Assert.Equal(list[i], myList[i]);
        }

        Assert.True(primitive.IsValid);
    }

    private void _List3()
    {
        Primitive primitive = new();

        var list = new List<List3Info>
        {
            new()
            {
                Number = int.MaxValue,
                String = Guid.NewGuid().ToString(),
                Bool = true,
                List =
                [
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString()
                ],

                Array =
                [
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString()
                ],
                SubClass = new()
                {
                    String = Guid.NewGuid().ToString()
                }
            },
            new()
            {
                Number = int.MinValue,
                String = Guid.NewGuid().ToString(),
                Bool = false,
                List =
                [
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString()
                ],

                Array =
                [
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString(),
                    Guid.NewGuid().ToString()
                ],

                SubClass = new()
                {
                    String = Guid.NewGuid().ToString()
                }
            }
        };

        primitive.Add.List(list);

        var myList = primitive.Get.List<List3Info>();

        Assert.NotNull(myList);

        for (int i = 0; i < list.Count; i++)
        {
            Assert.Equal(list[i].Number, myList[i].Number);
            Assert.Equal(list[i].String, myList[i].String);
            Assert.Equal(list[i].Bool, myList[i].Bool);
            Assert.Equal(list[i].List, myList[i].List);

            Assert.Equal(list[i].Array, myList[i].Array);

            Assert.Equal(list[i].SubClass?.String, myList[i].SubClass?.String);
        }

        Assert.True(primitive.IsValid);
    }

    private class List3Info
    {
        public int Number { get; set; }
        public string? String { get; set; }
        public bool Bool { get; set; }
        public List<string>? List { get; set; }

        public string[]? Array { get; set; }

        public Sub? SubClass { get; set; }

        public class Sub
        {
            public string? String { get; set; }
        }
    }
}