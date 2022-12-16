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
  ```

#### Sample
```csharp
```

## Install

- #### Nuget
  ```csharp
  ```
