# Byter
Byter is a bytes serializer. It can serialize and deserialize from primitive type.

<br><hr><br>

## Install
- #### Nuget [SEE HERE](https://www.nuget.org/packages/Byter)
  ###### .NET CLI
  ```rb
  dotnet add package Byter --version 1.2.0
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
  `Float2` (Vector2),
  `Float3` (Vector3),
  `Float4` (Vector4 / Quaternion),
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
      Internally, before data is written a prefix is added in front of it, so when reading it always compares the prefix of the (data type) you want to read with the strings in the read buffer. if the prefixes do not match then o (Reader. Success = False), eg. If you write an (int) and try to read a float (Reader.Success = False) because the prefix of an (int) is different from that of a (float), it is recommended to read all the data and at the end check the success, if it is (Reader.Success = False) then one or more data is corrupt. This means that Writer and Reader add dipping to your write and read data.

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
    r.Seek(r.Position - sizeof(int) /* int size is 4 */);    
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
  # Install - recommend a stable branch e.g. "1.x" or use a fork repository
  git submodule add --name byter --branch main https://github.com/alec1o/byter vendor/byter

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
