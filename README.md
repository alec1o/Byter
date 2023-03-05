# Byter
#### Byte parse. Convert byte to object and object to byte

## Usage

#### Namespace
```csharp
using Byter
```
#### Types
```css
byte, bool, byte[], short, ushort, int, uint, long, ulong, float, double, char, string
```

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
  dotnet add package Byter --version 1.1.0
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
