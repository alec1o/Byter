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

| <sub>Nuget</sub>                                                    |
|---------------------------------------------------------------------|
| <sub>Install on [Nuget](https://www.nuget.org/packages/Byter)</sub> |

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
<th align="center" valign="top"><sub><strong>v1.x.x</strong></sub></th>
<td>
<details><summary>📄 <strong><sup><sub>Writer</sub></sup></strong></summary>

</details>
<details><summary>📄 <strong><sup><sub>Reader</sub></sup></strong></summary>

### Constructor
- ###### (``byte[]`` buffer) :     ``Reader``
- ###### (``Writer`` writer) :     ``Reader``
- ###### (ref ``Writer`` writer) : ``Reader``

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

```csharp
```

</details>
</td>
</tr>

<tr><th></th></tr>

<tr>
<th align="center" valign="top"><sub><strong>v2.x.x</strong></sub></th>
<td>
<details><summary>📄 <strong><sup><sub>Writer</sub></sup></strong></summary>

```csharp
```

</details>
<details><summary>📄 <strong><sup><sub>Reader</sub></sup></strong></summary>

```csharp
```

</details>
<details><summary>📄 <strong><sup><sub>Example</sub></sup></strong></summary>

```csharp
```

</details>
</td>
</tr>

<tr><th></th></tr>

<tr>
<th align="center" valign="top"><sub><strong>v3.x.x</strong></sub></th>
<td>
<details><summary>📄 <strong><sup><sub>Primitive</sub></sup></strong></summary>

```csharp
```

</details>
<details><summary>📄 <strong><sup><sub>Writer & Reader <i>(namespace)</i></sub></sup></strong></summary>

```csharp
```

</details>
<details><summary>📄 <strong><sup><sub>Example</sub></sup></strong></summary>

```csharp
```

</details>
</td>
</tr>
</table>

<br>
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
