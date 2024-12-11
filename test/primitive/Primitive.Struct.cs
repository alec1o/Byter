using System;
using System.Collections.Generic;
using Byter;
using Xunit;

namespace Test.Primitives;

public partial class Primitives
{
    [Fact]
    public void _Struct()
    {
        Primitive primitive = new();

        var real = new MyComplexStruct
        {
            Number = int.MinValue,
            String = Guid.NewGuid().ToString(),
            Bool = true,
            ByteArray = Guid.NewGuid().ToString().GetBytes(),
            StringList =
            [
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            ],
            SubStructList =
            [
                MyComplexStruct.MySubStruct.Random(),
                MyComplexStruct.MySubStruct.Random(),
                MyComplexStruct.MySubStruct.Random()
            ],
            SubClassList =
            [
                MyComplexStruct.MySubClass.Random(),
                MyComplexStruct.MySubClass.Random(),
                MyComplexStruct.MySubClass.Random()
            ],

            StringArray =
            [
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString(),
                Guid.NewGuid().ToString()
            ],
            SubStructArray =
            [
                MyComplexStruct.MySubStruct.Random(),
                MyComplexStruct.MySubStruct.Random(),
                MyComplexStruct.MySubStruct.Random()
            ],
            SubClassArray =
            [
                MyComplexStruct.MySubClass.Random(),
                MyComplexStruct.MySubClass.Random(),
                MyComplexStruct.MySubClass.Random()
            ],

            SubClass = MyComplexStruct.MySubClass.Random(),
            SubStruct = MyComplexStruct.MySubStruct.Random()
        };

        primitive.Add.Struct(real);

        var clone = primitive.Get.Struct<MyComplexStruct>();

        Assert.Equal(real.Number, clone.Number);
        Assert.Equal(real.String, clone.String);
        Assert.Equal(real.Bool, clone.Bool);
        Assert.Equal(real.ByteArray, clone.ByteArray);

        for (var i = 0; i < real.StringList.Count; i++) Assert.Equal(real.StringList[i], clone.StringList[i]);

        for (var i = 0; i < real.SubClassList.Count; i++)
        {
            Assert.Equal(real.SubClassList[i].Number, clone.SubClassList[i].Number);
            Assert.Equal(real.SubClassList[i].String, clone.SubClassList[i].String);
        }

        for (var i = 0; i < real.SubStructList.Count; i++)
        {
            Assert.Equal(real.SubStructList[i].Number, clone.SubStructList[i].Number);
            Assert.Equal(real.SubStructList[i].String, clone.SubStructList[i].String);
        }

        for (var i = 0; i < real.StringArray.Length; i++) Assert.Equal(real.StringArray[i], clone.StringArray[i]);

        for (var i = 0; i < real.SubClassArray.Length; i++)
        {
            Assert.Equal(real.SubClassArray[i].Number, clone.SubClassArray[i].Number);
            Assert.Equal(real.SubClassArray[i].String, clone.SubClassArray[i].String);
        }

        for (var i = 0; i < real.SubStructArray.Length; i++)
        {
            Assert.Equal(real.SubStructArray[i].Number, clone.SubStructArray[i].Number);
            Assert.Equal(real.SubStructArray[i].String, clone.SubStructArray[i].String);
        }

        {
            Assert.Equal(real.SubClass.Number, clone.SubClass.Number);
            Assert.Equal(real.SubClass.String, clone.SubClass.String);
        }
        {
            Assert.Equal(real.SubStruct.Number, clone.SubStruct.Number);
            Assert.Equal(real.SubStruct.String, clone.SubStruct.String);
        }
        Assert.True(primitive.IsValid);
    }

    [Serializable]
    private struct MyComplexStruct
    {
        public int Number { get; set; }
        public string String { get; set; }
        public bool Bool { get; set; }
        public byte[] ByteArray { get; set; }
        public List<string> StringList { get; set; }
        public List<MySubClass> SubClassList { get; set; }
        public List<MySubStruct> SubStructList { get; set; }

        public string[] StringArray { get; set; }
        public MySubClass[] SubClassArray { get; set; }
        public MySubStruct[] SubStructArray { get; set; }

        public MySubClass SubClass { get; set; }
        public MySubStruct SubStruct { get; set; }

        [Serializable]
        public struct MySubStruct
        {
            public long Number { get; set; }
            public string String { get; set; }

            public static MySubStruct Random()
            {
                return new MySubStruct
                {
                    Number = new Random().Next(int.MinValue, int.MaxValue),
                    String = Guid.NewGuid().ToString()
                };
            }
        }

        [Serializable]
        public class MySubClass
        {
            public long Number { get; set; }
            public string String { get; set; } = null!;

            public static MySubClass Random()
            {
                return new MySubClass
                {
                    Number = new Random().Next(int.MinValue, int.MaxValue),
                    String = Guid.NewGuid().ToString()
                };
            }
        }
    }
}