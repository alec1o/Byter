<div align="right">
<table>
<td aligh="right">
<p></p>
<sup>⭐ Your star is the light at the end of our tunnel.<br> Lead us out of the darkness by starring <a href="https://github.com/alec1o/Byter">Byter on GitHub</a>.<br> Star me please, I beg you! 💙</sup>
</td>
</table>
</div>

<br>

<h1 align="center"><a href="https://github.com/alec1o/Byter">Byter</a></h1>

<h6 align="center"><sub>
powered by <a href="https://github.com/alec1o">ALEC1O</a><sub/>
</h6>

<div align="center">
  <a href="#">
    <img align="center" src="static/logo/Byter-logo-512/sprite_1.png" width="128px" alt="byter logo">
  </a>
</div>

##### Project

> <sub>Get basic information about this project called [Byter](https://github.com/alec1o/Byter)</sub>

<table>
<tr>
  <th align="center" valign="center"><sub><strong>Overview</strong></sub></th>
<td>
<br>
<sub>About
Byter is a C# serializer. It can serialize and deserialize from primitive type e.g (class, struct, list, array, string, int, long, double, ...), It can serialize complex data fast and easy.</sub>
<br>
<br>
</td>
</tr>
<tr>
  <th align="center" valign="center"><sub><strong>Website</strong></sub></th>
<td>
<br>
<sub>Repository: <a href="https://github.com/alec1o/Byter"><i>github.com/alec1o/byter</i></a></sub><br>
<br>
</td>
</tr>
</table>

<br>

##### Installing

> <sub>Official publisher</sub>

<table>
<tr>
<th valign="center" align="center"><sub>Nuget</sub></th>
<th valign="center" align="center"><sub>.NET CLI</sub></th>
<th valign="center" align="center"><sub>Netly</sub></th>
</tr>
<tr>
<td valign="top" align="left">

<h6><sup>Install on <a href="https://www.nuget.org/packages/Byter">Nuget</a></sup></h6>

</td>
<td valign="top" align="left">

```rb
dotnet add package Byter --version 3.0.0
```

</td>
<td valign="top" align="left">

<h6><sup>Embedded, <a href="https://github.com/alec1o/Netly">Since version 2.x.x</a></sup></h6>

</td>
</tr>
</table>

<br>

##### Versions

> <sub>Notable changes</sub>

<table>
<tr> <!-- title -->
<th><sub>v1.x.x</sub></th>
<th><sub>v2.x.x</sub></th>
<th><sub>v3.x.x</sub></th>
</tr>
<tr> <!-- status -->
<td valign="center" align="center"><sup><sub><i>Stable</i></sub></sup></td>
<td valign="center" align="center"><sup><sub><i>Stable</i></sub></sup></td>
<td valign="center" align="center"><sup><sub><i>Stable</i></sub></sup></td>
</tr>
<tr> <!-- row #1 -->
<td valign="top" align="left">
<sub>
<i>Main (Reader & Writer)</i> Types:
<br>
&nbsp; <code>byte</code>
&nbsp; <code>bool</code>
&nbsp; <code>byte[]</code>
<br>
&nbsp; <code>short</code>
&nbsp; <code>ushort</code>
&nbsp; <code>int</code>
<br>
&nbsp; <code>uint</code>
&nbsp; <code>long</code>
&nbsp; <code>ulong</code>
<br>
&nbsp; <code>float</code>
&nbsp; <code>double</code>
&nbsp; <code>char</code>
<br>
&nbsp; <code>string</code>
</sub>
</td>
<td valign="top" align="left">
<sub>
New <i>(Reader & Writer)</i> Types:
<br>&emsp;<code>Float2</code> (Vector2)
<br>&emsp;<code>Float3</code> (Vector3)
<br>&emsp;<code>Float4</code> (Vector4 / Quaternion)
</sub>
</td>
<td valign="top" align="left">
<sub>
Bug Fix. <i><strong>(Reader & Writer)</strong></i>
<br><br>Support: <i><strong>*Primitive</strong></i>
<br><br>New usage paradigms <i><strong>*Primitive</strong></i>
<br><br>*Primitive Types:
<br>
&nbsp; <code>bool</code>
&nbsp; <code>byte</code>
<br>
&nbsp; <code>char</code>
&nbsp; <code>short</code>
&nbsp; <code>ushort</code>
<br>
&nbsp; <code>int</code>
&nbsp; <code>uint</code>
&nbsp; <code>float</code>
<br>
&nbsp; <code>long</code>
&nbsp; <code>byte[]</code>
&nbsp; <code>ulong</code>
&nbsp; <code>double</code>
<br>
&nbsp; <code>string</code>
<br>
&nbsp;&nbsp;&nbsp;<i>*highlights</i>
<br>
&nbsp; <code>enum*</code>
&nbsp; <code>sbyte*</code>
&nbsp; <code>DateTime*</code>
<br>
&nbsp; <code>decimal*</code>
&nbsp; <code>class*</code>
&nbsp; <code>struct*</code>
<br>
&nbsp; <code>array*</code>
&nbsp; <code>list*</code>
&nbsp; <code>BigInteger*</code>
</sub></td>
</tr>
<tr> <!-- row #2 -->
<td valign="top" align="left"><sub>Used by. <a href="https://github.com/alec1o/Netly">Netly v2</a></sub></td>
<td valign="top" align="left"><sub>Used by. <a href="https://github.com/alec1o/Netly">Netly v3</a></sub></td>
<td valign="top" align="left"><sub>Used by. <a href="https://github.com/alec1o/Netly">Netly v4</a></sub></td>
</tr>
</table>

<br>

##### Usage

> <sub>Integration and interaction example codes</sub>


<table>

<tr>
<th align="center" valign="top"><sub><strong>v1.x.x<br>v2.x.x</strong></sub></th>
<td>

<details><summary>📄 <strong><sup><sub>Writer</sub></sup></strong></summary>

### Constructor

- ###### () :                      ``Writer`` <br><sub>Create instance with empty internal buffer</sub>
- ###### (``Writer`` writer) :     ``Writer`` <br><sub>Create instance and copy buffer of <i>(Writer)</i> as internal buffer</sub>
- ###### (ref ``Writer`` writer) : ``Writer`` <br><sub>Create instance and copy buffer of <i>(ref Writer)</i> as internal buffer</sub>

### Proprieties

- ###### Length :   ``int`` <br><sub>Return buffer length.</sub>

### Methods

- ###### Write(T value) :   ``void`` <br><sub>Write content in internal buffer</sub>
- ###### GetBytes() :     ``byte[]`` <br><sub>Return buffer from <i>(Writer)</i> instance as <i>byte[])</i> </sub>
- ###### GetList() :  ``List<byte>`` <br><sub>Return buffer from <i>(Writer)</i> instance as <i>List&lt;byte&gt;</i> </sub>
- ###### Clear():           ``void`` <br><sub>Clear internal buffer from <i>(Writer)</i> instance</sub>

</details>
<details><summary>📄 <strong><sup><sub>Reader</sub></sup></strong></summary>

### Constructor

- ###### (``byte[]`` buffer) :     ``Reader`` <br><sub>Create instance using <i>(Byte[])</i> as internal buffer</sub>
- ###### (``Writer`` writer) :     ``Reader`` <br><sub>Create instance using <i>(Writer)</i> as internal buffer</sub>
- ###### (ref ``Writer`` writer) : ``Reader`` <br><sub>Create instance using <i>(ref Writer)</i> as internal buffer</sub>

### Proprieties

- ###### Success : ``bool`` <br><sub>Return true if deserialized successful.</sub>
- ###### Position : ``int`` <br><sub>Return current read index.</sub>
- ###### Length :   ``int`` <br><sub>Return buffer length.</sub>

### Methods

- ###### Seek(``int`` position) :                    ``void`` <br><sub>Move position (internal buffer index)</sub>
- ###### Read<``T``>() :                                ``T`` <br><sub>Read content from iternal buffer.</sub>
- ###### Read<``string``>(``Encoding`` encoding) : ``string`` <br><sub>Read custom encoding string.</sub>

</details>
<details><summary>📄 <strong><sup><sub>Example</sub></sup></strong></summary>

- ###### Writer
    ```csharp
    using Byter;
    
    Writer w = new();
    
    // write data
  
    w.Write("Powered by ALEC1O");
    w.Write("由 ALEC1O 提供支持", Encoding.UTF32);
    w.Write((int)1000000);` // 1.000.000
    w.Write((char)'A');
    w.Write((long)-1000000000); // -100.0000.000
    w.Write((byte[])[0, 1, 2, 3]);
    
    // Float(1|2|3) only available in version 2
    w.Write(new Float2(-100F, 300F));
    w.Write(new Float3(-100F, 300F, 600F));
    w.Write(new Float4(-100F, 300F, 600F, 900F));
    
    // get buffer
    
    byte[] buffer = w.GetBytes();
    
    // example send buffer
    Magic.Send(buffer);
    ```
- ###### Reader
    ```csharp
    using Byter;
    
    // example receive buffer
    byte[] buffer = Magic.Receive();
    
    // create instance
    Reader r = new()
        
    // read data
    
    string noticeInEnglish = r.Read<string>(); // Powered by ALEC1O
    string noticeInChinese = r.Read<string>(Encoding.UTF32); // 由 ALEC1O 提供支持
    int myInt = r.Read<int>(); // 1.000.000
    char myChar = r.Read<char>(); // 'A'
    long myLong = r.Read<long>(); // -100.0000.000
    byte[] myBytes = r.Read<byte[]>(); // [0, 1, 2, 3]
    
    // Float(1|2|3) only available in version 2
    Float2 myFloat2 = r.Read<Float2>(); // [x: -100F] [y: 300F]
    Float3 myFloat3 = r.Read<Float3>(); // [x: -100F] [y: 300F] [z: 600F]
    Float4 myFloat4 = r.Read<Float4>(); // [x: -100F] [y: 300F] [z: 600F] [w: 900F]
    
    if (r.Sucess)
    {
        // sucess on read all data
    }
    else
    {
        // one or more data isn't found when deserialize. Might ignore this buffer!
    }
    ```

- ###### Dynamic Read Technical
    ```csharp
    var r = new Reader(...);
    
    var topic = r.Read<string>(Encoding.ASCII);
    
    if(!r.Sucess) return; // ignore this 
    
    if (topic == "login")
    {
        string username = r.Read<string>(Encoding.UTF32);
        string password = r.Read<string>(Encoding.ASCII);
        
        if (!r.Sucess) return; // ignore this
        // login user...
    }
    else if(topic == "get user address")
    {
        ulong userId  = r.Read<ulong>();
        string token = r.Read<string>(Encoding.ASCII);
        
        if (!r.Sucess) return; // ignore this
        // get user adress...
    }
    ...
    else
    {
        // ignore this. (Topic not found)
    }
    ```

</details>
</td>
</tr>

<tr><th></th></tr>

<tr>
<th align="center" valign="top"><sub><strong>v3.x.x</strong></sub></th>
<td>

<details><summary>📄 <strong><sup><sub>Primitive</sub></sup></strong></summary>

### Constructor

- ###### () :                      ``Primitive`` <br><sub>Create instance with empty internal buffer</sub>
- ###### (``byte[]`` buffer) :     ``Primitive`` <br><sub>Create instance using (Byte[]) as internal buffer</sub>

### Proprieties

- ###### Position :      ``int`` <br><sub>Return internal reading index/position.</sub>
- ###### IsValid :      ``bool`` <br><sub>Return (true) if data was read successful. otherwise (false)</sub>
- ###### Add : ``IPrimitiveAdd`` <br><sub>Object used to (read/get) content from internal (Primitive) buffer</sub>
- ###### Get : ``IPrimitiveGet`` <br><sub>Object used to (write/add) content in internal (Primitive) buffer</sub>

### Methods

- ###### GetBytes() :     ``byte[]`` <br><sub>Return buffer from <i>(Primitive)</i> instance as <i>byte[])</i> </sub>
- ###### GetList() :  ``List<byte>`` <br><sub>Return buffer from <i>(Primitive)</i> instance as <i>List&lt;byte&gt;</i> </sub>
- ###### Reset():           ``void`` <br><sub>Clear internal buffer from <i>(Primitive)</i> instance</sub>

</details>

<details><summary>📄 <strong><sup><sub>IPrimitiveAdd</sub></sup></strong></summary>

### Methods

- ###### Bool(``bool`` value)             ``void`` <br><sub>(Write/Add) element typeof(bool) in internal buffer</sub>
- ###### Byte(``byte`` value)             ``void`` <br><sub>(Write/Add) element typeof(byte) in internal buffer</sub>
- ###### SByte(``sbyte`` value)           ``void`` <br><sub>(Write/Add) element typeof(sbyte) in internal buffer</sub>
- ###### Char(``char`` value)             ``void`` <br><sub>(Write/Add) element typeof(char) in internal buffer</sub>
- ###### Short(``short`` value)           ``void`` <br><sub>(Write/Add) element typeof(short) in internal buffer</sub>
- ###### UShort(``ushort`` value)         ``void`` <br><sub>(Write/Add) element typeof(ushort) in internal buffer</sub>
- ###### Int(``int`` value)               ``void`` <br><sub>(Write/Add) element typeof(int) in internal buffer</sub>
- ###### UInt(``uint`` value)             ``void`` <br><sub>(Write/Add) element typeof(uint) in internal buffer</sub>
- ###### Float(``float`` value)           ``void`` <br><sub>(Write/Add) element typeof(float) in internal buffer</sub>
- ###### Enum<``T``>(``T`` value)         ``void`` <br><sub>(Write/Add) element typeof(enum) in internal buffer</sub>
- ###### Long(``long`` value)             ``void`` <br><sub>(Write/Add) element typeof(long) in internal buffer</sub>
- ###### ULong(``ulong`` value)           ``void`` <br><sub>(Write/Add) element typeof(ulong) in internal buffer</sub>
- ###### Double(``double`` value)         ``void`` <br><sub>(Write/Add) element typeof(double) in internal buffer</sub>
- ###### DateTime(``DateTime`` value)     ``void`` <br><sub>(Write/Add) element typeof(DateTime) in internal buffer</sub>
- ###### Decimal(``decimal`` value)       ``void`` <br><sub>(Write/Add) element typeof(decimal) in internal buffer</sub>
- ###### String(``string`` value)         ``void`` <br><sub>(Write/Add) element typeof(string) in internal buffer</sub>
- ###### Class<``T``>(``T`` value)        ``void`` <br><sub>(Write/Add) element typeof(T) in internal buffer</sub>
- ###### Struct<``T``>(``T`` value)       ``void`` <br><sub>(Write/Add) element typeof(T) in internal buffer</sub>
- ###### Array<``T``>(``T`` value)        ``void`` <br><sub>(Write/Add) element typeof(T[]) in internal buffer</sub>
- ###### List<``T``>(``List<T>`` value)   ``void`` <br><sub>(Write/Add) element typeof(List<T>) in internal buffer</sub>
- ###### BigInteger(``BigInteger`` value) ``void`` <br><sub>(Write/Add) element typeof(BigInteger) in internal buffer</sub>
- ###### Bytes(``byte[]`` value)          ``void`` <br><sub>(Write/Add) element typeof(byte[]) in internal buffer</sub>

</details>

<details><summary>📄 <strong><sup><sub>IPrimitiveGet</sub></sup></strong></summary>

### Methods

- ###### Bool()             ``bool`` <br><sub>(Read/Get) element typeof(bool) from internal buffer</sub>
- ###### Byte()             ``byte`` <br><sub>(Read/Get) element typeof(byte) from internal buffer</sub>
- ###### SByte()           ``sbyte`` <br><sub>(Read/Get) element typeof(sbyte) from internal buffer</sub>
- ###### Char()             ``char`` <br><sub>(Read/Get) element typeof(char) from internal buffer</sub>
- ###### Short()           ``short`` <br><sub>(Read/Get) element typeof(short) from internal buffer</sub>
- ###### UShort()         ``ushort`` <br><sub>(Read/Get) element typeof(ushort) from internal buffer</sub>
- ###### Int()               ``int`` <br><sub>(Read/Get) element typeof(int) from internal buffer</sub>
- ###### UInt()             ``uint`` <br><sub>(Read/Get) element typeof(uint) from internal buffer</sub>
- ###### Float()           ``float`` <br><sub>(Read/Get) element typeof(float) from internal buffer</sub>
- ###### Enum<``T``>()         ``T`` <br><sub>(Read/Get) element typeof(enum) from internal buffer</sub>
- ###### Long()             ``long`` <br><sub>(Read/Get) element typeof(long) from internal buffer</sub>
- ###### ULong()           ``ulong`` <br><sub>(Read/Get) element typeof(ulong) from internal buffer</sub>
- ###### Double()         ``double`` <br><sub>(Read/Get) element typeof(double) from internal buffer</sub>
- ###### DateTime()     ``DateTime`` <br><sub>(Read/Get) element typeof(DateTime) from internal buffer</sub>
- ###### Decimal()       ``decimal`` <br><sub>(Read/Get) element typeof(decimal) from internal buffer</sub>
- ###### String()         ``string`` <br><sub>(Read/Get) element typeof(string) from internal buffer</sub>
- ###### Class<``T``> ()       ``T`` <br><sub>(Read/Get) element typeof(T) from internal buffer</sub>
- ###### Struct<``T``>()       ``T`` <br><sub>(Read/Get) element typeof(T) from internal buffer</sub>
- ###### Array<``T``>()      ``T[]`` <br><sub>(Read/Get) element typeof(T[]) from internal buffer</sub>
- ###### List<``T``>()   ``List<T>`` <br><sub>(Read/Get) element typeof(List<T) from in internal buffer</sub>
- ###### BigInteger() ``BigInteger`` <br><sub>(Read/Get) element typeof(BigInteger) from internal buffer</sub>
- ###### Bytes()          ``byte[]`` <br><sub>(Read/Get) element typeof(byte[]) from internal buffer</sub>

</details>

<details><summary>📄 <strong><sup><sub>Example</sub></sup></strong></summary>

- ###### Add Element
    ```csharp
    using Byter;
    
    Primitive primitive = new();
    
    // write elements
  
    primitive.Add.Class(myCharacterInfoClass);
    primitive.Add.Array(myCharacterArray);
    primitive.Add.List(myLogList);
    primitive.Add.Struct(myDeviceStruct);
    primitive.Add.DateTime(DateTime.UtcNow);
    primitive.Add.Enum(MyEnum.Option1);
    primitive.Add.Bytes(myImageBuffer);
    
    // send buffer
  
    byte[] buffer = primitive.GetBytes();
    Magic.Send(buffer); // EXAMPLE!
    ```

- ###### Get Element
    ```csharp
    using Byter;
    
    // receive bugger
    
    byte[] buffer = Magic.Receive(); // EXAMPLE!
    
    Primitive primitive = new(buffer);
    
    // read elements
    
    var myCharacterInfoClass = primitive.Get.Class<CharacterInfoClass>();
    var myCharacterArray = primitive.Get.Array<Character>();
    var myLogList = primitive.Get.List<string>();
    var myDeviceStruct = primitive.Get.Struct<DeviceStruct>();
    var myTime = primitive.Get.DateTime();
    var myEnum = primitive.Get.Enum<MyEnum>();
    var myImageBuffer = primitive.Get.Bytes();
    
    if (primitive.IsValid)
    {
        // sucess on read all data
    }
    else
    {
        // one or more data isn't found when deserialize. Might ignore this buffer!
    }
    
    ```

- ###### Dynamic Read Technical
    ```csharp
    Primitive primitive = new(...);
    
    var topic = primitive.Get.String();
    
    if(!primitive.IsValid) return; // ignore this 
    
    if (topic == "login")
    {
        var loginInfo = primitive.Get.Class<LoginInfo>();
        
        if (!primitive.IsValid) return; // ignore this
        // login user...
    }
    else if (topic == "get user address")
    {
        var getUserAddressInfo = primitive.Get.Class<GetUserAddressInfo>();
        
        if (!primitive.IsValid) return; // ignore this
        // get user adress...
    }
    ...
    else
    {
        // ignore this. (Topic not found)
    }
    ```

</details>
</td>
</tr>
</table>

<br>

##### Overhead <sup><i>(supported types list)</i></sup>

> <sub>Byter overhead information</sub>

| <sub>Type</sub>       | <sub>Primitive <i>(overhead + size = total)</i></sub>                                 | <sub>Writer/Reader <i>(overhead + size = total)</i></sub>                            |
|-----------------------|---------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------|
| <sub>Bool</sub>       | ✔️  <i>(1 + 1 = 2 bytes)</i>                                                          | ✔️ <i>(2 + 1 = 3 bytes)</i>                                                          |
| <sub>Byte</sub>       | ✔️  <i>(1 + 1 = 2 bytes)</i>                                                          | ✔️ <i>(2 + 1 = 3 bytes)</i>                                                          |
| <sub>SByte</sub>      | ✔️  <i>(1 + 2 = 2 bytes)</i>                                                          | 🚫                                                                                   |
| <sub>Char</sub>       | ✔️  <i>(1 + 2 = 3 bytes)</i>                                                          | ✔️ <i>(2 + 2 = 4 bytes)</i>                                                          |
| <sub>Short</sub>      | ✔️  <i>(1 + 2 = 3 bytes)</i>                                                          | ✔️ <i>(2 + 2 = 4 bytes)</i>                                                          |
| <sub>UShort</sub>     | ✔️  <i>(1 + 2 = 3 bytes)</i>                                                          | ✔️ <i>(2 + 2 = 4 bytes)</i>                                                          |
| <sub>Int</sub>        | ✔️  <i>(1 + 4 = 5 bytes)</i>                                                          | ✔️ <i>(2 + 4 = 6 bytes)</i>                                                          |
| <sub>UInt</sub>       | ✔️  <i>(1 + 4 = 5 bytes)</i>                                                          | ✔️ <i>(2 + 4 = 6 bytes)</i>                                                          |
| <sub>Float</sub>      | ✔️  <i>(1 + 4 = 5 bytes)</i>                                                          | ✔️ <i>(2 + 4 = 6 bytes)</i>                                                          |
| <sub>Enum</sub>       | ✔️  <i>(1 + 4 = 5 bytes)</i>                                                          | 🚫                                                                                   |
| <sub>Long</sub>       | ✔️  <i>(1 + 8 = 9 bytes)</i>                                                          | ✔️ <i>(2 + 8 = 10 bytes)</i>                                                         |
| <sub>ULong</sub>      | ✔️  <i>(1 + 8 = 9 bytes)</i>                                                          | ✔️ <i>(2 + 8 = 10 bytes)</i>                                                         |
| <sub>Double</sub>     | ✔️  <i>(1 + 8 = 9 bytes)</i>                                                          | ✔️ <i>(2 + 8 = 10 bytes)</i>                                                         |
| <sub>DateTime</sub>   | ✔️  <i>(1 + 8 = 9 bytes)</i>                                                          | 🚫                                                                                   |
| <sub>Decimal</sub>    | ✔️  <i>(1 + 16 = 17 bytes)</i>                                                        | 🚫                                                                                   |
| <sub>String</sub>     | ✔️  <i>(5 + ? = <sup>+</sup>5 bytes)</i> <sup>*UTF8</sup>                             | ✔️ <i>(5 + ? = <sup>+</sup>5 bytes)</i>                                              |
| <sub>Class</sub>      | ✔️  <i>(1 + ? = <sup>+</sup>1 byte)</i>                                               | 🚫                                                                                   |
| <sub>Struct</sub>     | ✔️  <i>(1 + ? = <sup>+</sup>1 byte)</i>                                               | 🚫                                                                                   |
| <sub>Array</sub>      | ✔️  <i>(3 + ? = <sup>+</sup>3 bytes)</i>  <sup>*Max. 65535</sup>                      | 🚫                                                                                   |
| <sub>List</sub>       | ✔️  <i>(3 + ? = <sup>+</sup>3 bytes)</i>  <sup>*Max. 65535</sup>                      | 🚫                                                                                   |
| <sub>BigInteger</sub> | ✔️  <i>(3 + ? = <sup>+</sup>3 bytes)</i>                                              | 🚫                                                                                   |
| <sub>Bytes</sub>      | ✔️  <i>(5 + ? = <sup>+</sup>5 bytes)</i> <sup>*Max. 4.294.967.295 *(~4billions)</sup> | ✔️ <i>(6 + ? = <sup>+</sup>5 bytes)</i> <sup>*Max. 2.147.483.647 *(~2billions)</sup> |

<br>















<details>
<summary>Legacy Docs <i>(v1.x.x - v2.x.x)</i></summary>

# Byter

Byter is a bytes serializer. It can serialize and deserialize from primitive type.

> ###### Byter is very stable, super easy to learn, extremely fast and inexpensive (2 bytes or ``sizeof(char)`` of overhead per data written) and ``100%`` written in ``C#`` and it's FREE!

<br><hr><br>

## Install

- #### Nuget [SEE HERE](https://www.nuget.org/packages/Byter)
  ###### .NET CLI
  ```rb
  dotnet add package Byter --version 2.0
  ```
  ###### Git submodule
  See how add as git submodule? See on bottom of this docs

<br><hr/>

## Usage

#### Namespace

```csharp
using Byter
```

#### Types

```ts
[
    `byte`,
    `bool`,
    `byte[]`,
    `short`,
    `ushort`,
    `int`,
    `uint`,
    `long`,
    `ulong`,
    `float`,
    `double`,
    `char`,
    `string`,
    `Float2`(Vector2),
    `Float3`(Vector3),
    `Float4`(Vector4 / Quaternion),
]
```

<hr/>

## Writer

> Constructor

-

```cs
_ = new Writer();                          // Create default instance
_ = new Writer(new Writer());              // Create instance and copy from existing Writer
_ = new Writer(ref new Writer());          // Create instance and copy from existing Writer (using ref)
```

<br>

> Proprietary

- #### ``Length``
  ```cs
  using Byter;

  var w = new Writer();

  // Get lenght of buffer
  int lenght = w.Length; 
  ```

<br/>

> Methods

- #### ``Write(dynamic value)``
  ```cs
  using Byter;

  // Create writer instance;
  using var w = new Writer();
  
  // Write string
  w.Write("KEZERO");

  // Write char
  w.Write('K');

  // Write Float3 (Vector3)
  w.Write(new Float3(10F, 10F, 10F));

  // Get bytes (buffer)
  byte[] buffer = w.GetBytes();

  // Get byte list (buffer)
  List<byte> bytes = w.GetList();
  ```

- #### ``GetBytes()``
  ```cs
  using Byter;

  var w = new Writer();

  // Return buffer on <Writer> instance 
  byte[] buffer = w.GetBytes();
  ```

- #### ``GetList()``
  ```cs
  using Byter;

  var w = new Writer();

  // Return buffer on <Writer> instance as byte list 
  List<byte> bytes = w.GetList();
  ```

- #### ``Clear()``
  ```cs
  using Byter;

  var w = new Writer();
  w.Write((int)1000);
  w.Write((float)100f);

  // Clear internal buffer and reset internal index
  w.Clear();
  ```

<hr>

## Reader

> Constructor

-

```cs
_ = new Reader(new Writer());               // Create instance and copy buffer from existing Writer
_ = new Reader(ref new Writer());           // Create instance and copy buffer from existing Writer (ref Writer)
_ = new Reader(new byte[] { 1, 1, 1, 1 });  // Create instance from buffer (bytes (byte[]))
```

<br/>

> Proprietary

- #### ``Length``
  ```cs
  using Byter;

  byte[] buffer = ...;
  var r = new Reader(buffer);

  // Get lenght of buffer
  int lenght = r.Length; 
  ```

- #### ``Position``
  ```cs
  using Byter;

  byte[] buffer = ...;
  var r = new Reader(buffer);

  // return current index of readed buffer
  int position = r.Position; 
  ```

- #### ``Success``
    ```cs
    using Byter;

    byte[] buffer = ...;
    var r = new Reader(buffer);
    string name = r.Read<string>();
    int age = r.Read<int>();
    
    // return true if not exist problem on read values.
    // return false when have any error on read values;
    bool success = r.Success; 
    ```
    - ###### WARNING
      Internally, before data is written a prefix is added in front of it, so when reading it always compares the prefix
      of the (data type) you want to read with the strings in the read buffer. if the prefixes do not match then o (
      Reader. Success = False), eg. If you write an (int) and try to read a float (Reader.Success = False) because the
      prefix of an (int) is different from that of a (float), it is recommended to read all the data and at the end
      check the success, if it is (Reader.Success = False) then one or more data is corrupt. This means that Writer and
      Reader add dipping to your write and read data.

<br/>

> Methods

- #### ``Read<T>()`` ``Read<string>(Encoding encoding)``;
  ```cs
  using Byter;

  byte[] buffer = ...;

  // Create reader instance
  using r = new Reader(buffer);

  string name = r.Read<string>();
  char firstLatter = r.Read<char>();
  Float3 position = r.Read<Float3>();

  // Check if is success
  if (r.Success)
  {
      Console.WriteLine($"Name: {name}");
      Console.WriteLine($"First Latter: {firstLatter}");
      Console.WriteLine($"Position: {position}");
  }
  else
  {
      Console.WriteLine("Error on get data");
  }
  ```

- #### ``Seek(int position)``;
  ```cs
  using Byter;

  using var w = new Writer();
  w.Write("KEZERO");
  w.Write((int) 1024);

  using var r = new Reader(ref w);

  string name = r.Read<string>(); // name: KEZERO
  int age = r.Read<int>(); // age: 1024
  
  // Move index (Reader.Position) for target value "MIN VALUE IS 0";
  r.Seek(10); // move current index for read for 10 (when start read using .Read<Type> will start read on 10 index from buffer);

  // Reset internal position
  r.Seek(0);

  string name2 = r.Read<string>(); // name: KEZERO (because the start index of this string on buffer is 0)
  int age2 = r.Read<int>(); age: 1024;

  // NEED READ LAST INT
  r.Seek(r.Position - sizeof(int) + sizeof(char) /* int size is 4 + char size is 2. The 2 bytes is overhead of protocol */);    
  int age3 = r.Read<int>(); age: 1024 (because i return 4bytes before old current value)
  ```

<br/><hr/><br/>

#### Sample

```csharp
using Byter;

// writing
Writer writer = new();

writer.Write(1000); // index
writer.Write("{JSON}"); // content
writer.Write(new byte[]{ 1, 1, 1, 1 }); // image

// geting buffer
byte[] buffer = writer.GetBytes();
writer.Dispose(); // Destroy Writer

// reading
Reader reader = new(buffer);

int index = reader.Read<int>();
string json = reader.Read<string>();
byte[] image = reader.Read<byte[]>();

// Check error
if (!reader.Success) // IS FALSE
{
    Console.WriteLine("*** ERROR ****");
    return;
}

// Check success
Console.WriteLine("*** SUCCESS ****");      

// Output
Console.WriteLine($"Index: {index}");           // output: 1000
Console.WriteLine($"JSON : {json }");           // output: JSON
Console.WriteLine($"Image: {image.Length}");    // output: 4
Console.WriteLine($"Status: {reader.Success}"); // output: True

// Making error
float delay = reader.Read<float>();
                                                                                            /*
WARNING:                
if you reverse the reading order or try to read more data than added (Reader.Succes = False),
Remembering does not return exception when trying to read data that does not exist it just
returns the default construction, and (Reader.Success) will be assigned (False)             */

if (reader.Success)  // IS FALSE, THE IS NOT WRITED IN BUFFER
    Console.WriteLine($"Delay: {delay}");
else                // IS TRUE, THE DELAY NOT EXIST
    Console.WriteLine($"Delay not exist");

// Output of status
Console.WriteLine($"Status: {reader.Success}"); // output: False

reader.Dispose(); // Destroy Reader
```

<br/><hr/><br/>

#### Install using git submodule

  ```rb
  # Install - recommend a stable branch e.g. "1.x" or use a fork repository, --depth clone last sources
  git submodule add --name byter --depth 1 --branch main "https://github.com/alec1o/byter" vendor/byter

  # Rebuilding - Download repository and link it in file location, must add this step in dotnet.yaml if using
  git submodule update --init

  # Update submodule - Update and load new repository updates
  git submodule update --remote

  # PATH
  # |__ vendor
  # |   |__ byter
  # |      |__ src
  # |        |__ Byter.csproj
  # |
  # |__ app
  # |   |__ app.csproj
  # |
  # |__ app.sln
  # |__ .git
  # |__ .gitignore
  # |__ .gitmodules

  # .NET link on .sln
  cd <PATH>
  dotnet sln add vendor/byter/src/Byter.csproj

  # .NET link on .csproj
  cd app/
  dotnet add reference ../vendor/byter/src/Byter.csproj
  
  # Rebuild dependencies to be linked in the project
  dotnet restore
  ```

</details>

<br>
