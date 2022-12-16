# Byter
#### Byte parse. Convert byte to object and object to byte

## Usage

#### Namespace
```csharp
using Byter
```
#### Types
```css
byte, byte[], short, ushort, int, uint, long, ulong, float, double, char, string
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
  w.Write((byte[]), new byte[] { 1, 1, 1, 1 });  // Write bytes
  
  // Output
  byte[]      bytes = w.GetBytes();              // Get writes in Byte[]
  List<byte>  list  = w.GetList();               // Get writes in List<byte>
  
  // Other
  int position  = w.Position;                    // Return the write pointer position 
  int length    = w.Length;                      // Returns the length of bytes written
  w.Seek(position);                              // Moves the write pointer to any existing index
  w.Dispose();                                   // Destroy the Writer object
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
  byte    _byte     = r.Read<int>();             // Output: 255
  string  _string   = r.Read<string>();          // Output: "Byter"
  byte[]  _bytes    = r.Read<byte[]>();          // Output: [ 1, 1, 1, 1 ]
  
  // Output
  bool sucess    = r.Sucess;                     // Returns success if there was no error retrieving the data
  
  // Other
  int position  = w.Position;                    // Return the read pointer position 
  int length    = w.Length;                      // Returns the length of buffer
  w.Seek(position);                              // Moves the read pointer to any existing index
  w.Dispose();                                   // Destroy the Reader object
  ```

- #### Warning
  Internally, before data is written a prefix is added in front of it, so when reading it always compares the prefix of the (data type) you want to read with the strings in the read buffer. if the prefixes do not match then o (Reader. Success = False), eg. If you write an (int) and try to read a float (Reader.Success = False) because the prefix of an (int) is different from that of a (float), it is recommended to read all the data and at the end check the success, if it is (Reader.Success = False) then one or more data is corrupt. This means that Writer and Reader add dipping to your write and read data.

#### Sample
```csharp
using Byter;

#region Writer

var w = new Writer();

w.Write((string) "Byter Library");  // e.g. Name
w.Write((byte) 1);                  // e.g. Old
w.Write((int) 0);                   // e.g. Start
w.Write((long) 1024);               // e.g. Id
w.Write(new byte[]{ 1, 1, 1, 1 });  // e.g. Pdf
byte[] data = w.GetBytes();         // e.g. File

w.Dispose();                        // Destroy Writer

#endregion

#region Reader

var r = new Reader(data);

string name = r.Read<string>();     // Output: Byter Library
byte old = r.Read<byte>();          // Output: 1
int star = r.Read<int>();           // Start : 0
long id = r.Read<long>();           // Id    : 1024
byte[] pdf = r.Read<byte[]>();      // Pdf   : [ 1, 1, 1, 1 ]

r.Dispose();                        // Destroy Reader

#endregion
```

## Install

- #### Nuget
  ```csharp
  ```
