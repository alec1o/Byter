# Byter
Byter is a bytes serializer. It can serialize and deserialize from primitive type.

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
> Proprietary
  - #### ``Length``
    ```cs
    using Byter;

    byte[] buffer = ...;
    var r = new Reader(buffer);

    // Get lenght of buffer
    int lenght = r.Length; 
    ```

  - #### ``Position ``
    ```cs
    using Byter;

    byte[] buffer = ...;
    var r = new Reader(buffer);

    // return current index of readed buffer
    int position = r.Position; 
    ```
    
- #### ``Successs ``
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

> Methods
  - #### ``Read<T>()``, ``Read<string>(Encoding encoding)``;
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
    ``

- #### Writer
  ```csharp
  using Byter;
  using System.Text;
  
  // Create instance
  var w = new Writer();                          // Create default instance
  _     = new Writer(new byte[] { 1, 1, 1, 1 }); // Create instance with default data
  _     = new Writer(new Writer());              // Create instance and copy from existing Writer

  // Write data
  w.Write((char) 'A');                           // Write char
  w.Write((int) 1024);                           // Write int 
  w.Write((string) "Byter");                     // Write string
  w.Write((string) "Byter", Encoding.ASCII);     // Write string
  w.Write((byte[]) new byte[] { 1, 1, 1, 1 });   // Write bytes

  // Output
  byte[]      bytes = w.GetBytes();              // Get writes in Byte[]
  List<byte>  list  = w.GetList();               // Get writes in List<byte>

  // Other
  int length = w.Length;                         // Returns the length of bytes written
  w.Dispose();                                   // Destroy the Writer object

  // Console output
  Console.WriteLine($"Write length: {length}");
  Console.WriteLine($"Write bytes[] length: {bytes.Length}");
  Console.WriteLine($"Write List<byte> length: {list.Count}");
  w.Clear();
  Console.WriteLine($"Clear writer...");
  Console.WriteLine($"Write length: {w.Length}");
  ```

- #### Reader
  ```csharp
  using Byter;
  using System.Text;
  
  // Create sample input
  var w = new Writer();
  // Write sample datas
  w.Write((int) 1024);
  w.Write((byte) 255);
  w.Write((string) "Byter");
  w.Write((byte[]) new byte[] { 1, 1, 1, 1 }); 

  // Create instance      
  var r = new Reader(ref w);                     // Create instance and copy buffer from existing Writer
  _     = new Reader(new byte[] { 1, 1, 1, 1 }); // Create instance with bytes (byte[])

  // Read data
  int     _int      = r.Read<int>();             // Output: 1024
  byte    _byte     = r.Read<byte>();            // Output: 255
  string  _string   = r.Read<string>();          // Output: "Byter"
  byte[]  _bytes    = r.Read<byte[]>();          // Output: [ 1, 1, 1, 1 ]

  // Output
  bool success    = r.Success;                   // Returns success if there was no error retrieving the data

  // Other
  int position  = r.Position;                    // Return the read pointer position 
  int length    = r.Length;                      // Returns the length of buffer
  r.Seek(position);                              // Moves the read pointer to any existing index
  r.Dispose();                                   // Destroy the Reader object

  // Console output
  Console.WriteLine($"Int       -> {_int}     ");
  Console.WriteLine($"Byte      -> {_byte}    ");
  Console.WriteLine($"String    -> {_string}  ");
  Console.WriteLine($"Byte[]    -> {_bytes}   ");
  Console.WriteLine($"Success   -> {success}  ");
  Console.WriteLine($"Position  -> {position} ");
  Console.WriteLine($"Length    -> {length}   ");
  ```

- #### Warning
  Internally, before data is written a prefix is added in front of it, so when reading it always compares the prefix of the (data type) you want to read with the strings in the read buffer. if the prefixes do not match then o (Reader. Success = False), eg. If you write an (int) and try to read a float (Reader.Success = False) because the prefix of an (int) is different from that of a (float), it is recommended to read all the data and at the end check the success, if it is (Reader.Success = False) then one or more data is corrupt. This means that Writer and Reader add dipping to your write and read data.

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

## Install
- #### Nuget [SEE HERE](https://www.nuget.org/packages/Byter)
  ###### .NET CLI
  ```rb
  dotnet add package Byter --version 1.2.0
  ```
  
- #### Submodule
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
