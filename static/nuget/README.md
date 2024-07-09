<!--
Remove HTML tags: https://www.browserling.com/tools/html-strip
Recreate table:
-->

##### [Need better documentation? READ THIS IN GITHUB ___(click me)___](https://github.com/alec1o/Byter)
\
\
\
⭐ Your star is the light at the end of our tunnel. Lead us out of the darkness by starring Byter on GitHub. Star me
please, I beg you! 💙

Byter

powered by [ALEC1O](https://github.com/alec1o)

##### Project

> Get basic information about this project called [Byter](https://github.com/alec1o/Byter)

!Content removed: [Need better documentation? READ THIS IN GITHUB ___(click me)___](https://github.com/alec1o/Byter)


### Overview
  ##### About
  > Byter is a C# serializer. It can serialize and deserialize from primitive type e.g (class, struct, list, array, string,
  int, long, double, ...), It can serialize complex data fast and easy.
  ##### Website:
  > Repository: [GitHub](https://github.com/alec1o/byter)

##### Installing

> Official publisher

!Content removed: [Need better documentation? READ THIS IN GITHUB ___(click me)___](https://github.com/alec1o/Byter)



##### Usage

> Integration and interaction example codes

!Content removed: [Need better documentation? READ THIS IN GITHUB ___(click me)___](https://github.com/alec1o/Byter)


v1.x.x and v2.x.x

📄 Writer

### Constructor

- ###### () :                      ``Writer`` Create instance with empty internal buffer
- ###### (``Writer`` writer) :     ``Writer`` Create instance and copy buffer of (Writer) as internal buffer
- ###### (ref ``Writer`` writer) : ``Writer`` Create instance and copy buffer of (ref Writer) as internal buffer

### Proprieties

- ###### Length :   ``int`` Return buffer length.

### Methods

- ###### Write(T value) :   ``void`` Write content in internal buffer
- ###### GetBytes() :     ``byte[]`` Return buffer from (Writer) instance as byte[])
- ###### GetList() :  ``List`` Return buffer from (Writer) instance as List<byte>
- ###### Clear():           ``void`` Clear internal buffer from (Writer) instance

📄 Reader

### Constructor

- ###### (``byte[]`` buffer) :     ``Reader`` Create instance using (Byte[]) as internal buffer
- ###### (``Writer`` writer) :     ``Reader`` Create instance using (Writer) as internal buffer
- ###### (ref ``Writer`` writer) : ``Reader`` Create instance using (ref Writer) as internal buffer

### Proprieties

- ###### Success : ``bool`` Return true if deserialized successful.
- ###### Position : ``int`` Return current read index.
- ###### Length :   ``int`` Return buffer length.

### Methods

- ###### Seek(``int`` position) :                    ``void`` Move position (internal buffer index)
- ###### Read<``T``>() :                                ``T`` Read content from iternal buffer.
- ###### Read<``string``>(``Encoding`` encoding) : ``string`` Read custom encoding string.

📄 Example

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
    
    string noticeInEnglish = r.Read(); // Powered by ALEC1O
    string noticeInChinese = r.Read(Encoding.UTF32); // 由 ALEC1O 提供支持
    int myInt = r.Read(); // 1.000.000
    char myChar = r.Read(); // 'A'
    long myLong = r.Read(); // -100.0000.000
    byte[] myBytes = r.Read(); // [0, 1, 2, 3]
    
    // Float(1|2|3) only available in version 2
    Float2 myFloat2 = r.Read(); // [x: -100F] [y: 300F]
    Float3 myFloat3 = r.Read(); // [x: -100F] [y: 300F] [z: 600F]
    Float4 myFloat4 = r.Read(); // [x: -100F] [y: 300F] [z: 600F] [w: 900F]
    
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
    
    var topic = r.Read(Encoding.ASCII);
    
    if(!r.Sucess) return; // ignore this 
    
    if (topic == "login")
    {
        string username = r.Read(Encoding.UTF32);
        string password = r.Read(Encoding.ASCII);
        
        if (!r.Sucess) return; // ignore this
        // login user...
    }
    else if(topic == "get user address")
    {
        ulong userId  = r.Read();
        string token = r.Read(Encoding.ASCII);
        
        if (!r.Sucess) return; // ignore this
        // get user adress...
    }
    ...
    else
    {
        // ignore this. (Topic not found)
    }
    ```

v3.x.x

📄 Primitive

### Constructor

- ###### () :                      ``Primitive`` Create instance with empty internal buffer
- ###### (``byte[]`` buffer) :     ``Primitive`` Create instance using (Byte[]) as internal buffer

### Proprieties

- ###### Position :      ``int`` Return internal reading index/position.
- ###### IsValid :      ``bool`` Return (true) if data was read successful. otherwise (false)
- ###### Add : ``IPrimitiveAdd`` Object used to (read/get) content from internal (Primitive) buffer
- ###### Get : ``IPrimitiveGet`` Object used to (write/add) content in internal (Primitive) buffer

### Methods

- ###### GetBytes() :     ``byte[]`` Return buffer from (Primitive) instance as byte[])
- ###### GetList() :  ``List`` Return buffer from (Primitive) instance as List<byte>
- ###### Reset():           ``void`` Clear internal buffer from (Primitive) instance

📄 IPrimitiveAdd

### Methods

- ###### Bool(``bool`` value)             ``void`` (Write/Add) element typeof(bool) in internal buffer
- ###### Byte(``byte`` value)             ``void`` (Write/Add) element typeof(byte) in internal buffer
- ###### SByte(``sbyte`` value)           ``void`` (Write/Add) element typeof(sbyte) in internal buffer
- ###### Char(``char`` value)             ``void`` (Write/Add) element typeof(char) in internal buffer
- ###### Short(``short`` value)           ``void`` (Write/Add) element typeof(short) in internal buffer
- ###### UShort(``ushort`` value)         ``void`` (Write/Add) element typeof(ushort) in internal buffer
- ###### Int(``int`` value)               ``void`` (Write/Add) element typeof(int) in internal buffer
- ###### UInt(``uint`` value)             ``void`` (Write/Add) element typeof(uint) in internal buffer
- ###### Float(``float`` value)           ``void`` (Write/Add) element typeof(float) in internal buffer
- ###### Enum<``T``>(``T`` value)         ``void`` (Write/Add) element typeof(enum) in internal buffer
- ###### Long(``long`` value)             ``void`` (Write/Add) element typeof(long) in internal buffer
- ###### ULong(``ulong`` value)           ``void`` (Write/Add) element typeof(ulong) in internal buffer
- ###### Double(``double`` value)         ``void`` (Write/Add) element typeof(double) in internal buffer
- ###### DateTime(``DateTime`` value)     ``void`` (Write/Add) element typeof(DateTime) in internal buffer
- ###### Decimal(``decimal`` value)       ``void`` (Write/Add) element typeof(decimal) in internal buffer
- ###### String(``string`` value)         ``void`` (Write/Add) element typeof(string) in internal buffer
- ###### Class<``T``>(``T`` value)        ``void`` (Write/Add) element typeof(T) in internal buffer
- ###### Struct<``T``>(``T`` value)       ``void`` (Write/Add) element typeof(T) in internal buffer
- ###### Array<``T``>(``T`` value)        ``void`` (Write/Add) element typeof(T[]) in internal buffer
- ###### List<``T``>(``List`` value)   ``void`` (Write/Add) element typeof(List) in internal buffer
- ###### BigInteger(``BigInteger`` value) ``void`` (Write/Add) element typeof(BigInteger) in internal buffer
- ###### Bytes(``byte[]`` value)          ``void`` (Write/Add) element typeof(byte[]) in internal buffer

📄 IPrimitiveGet

### Methods

- ###### Bool()             ``bool`` (Read/Get) element typeof(bool) from internal buffer
- ###### Byte()             ``byte`` (Read/Get) element typeof(byte) from internal buffer
- ###### SByte()           ``sbyte`` (Read/Get) element typeof(sbyte) from internal buffer
- ###### Char()             ``char`` (Read/Get) element typeof(char) from internal buffer
- ###### Short()           ``short`` (Read/Get) element typeof(short) from internal buffer
- ###### UShort()         ``ushort`` (Read/Get) element typeof(ushort) from internal buffer
- ###### Int()               ``int`` (Read/Get) element typeof(int) from internal buffer
- ###### UInt()             ``uint`` (Read/Get) element typeof(uint) from internal buffer
- ###### Float()           ``float`` (Read/Get) element typeof(float) from internal buffer
- ###### Enum<``T``>()         ``T`` (Read/Get) element typeof(enum) from internal buffer
- ###### Long()             ``long`` (Read/Get) element typeof(long) from internal buffer
- ###### ULong()           ``ulong`` (Read/Get) element typeof(ulong) from internal buffer
- ###### Double()         ``double`` (Read/Get) element typeof(double) from internal buffer
- ###### DateTime()     ``DateTime`` (Read/Get) element typeof(DateTime) from internal buffer
- ###### Decimal()       ``decimal`` (Read/Get) element typeof(decimal) from internal buffer
- ###### String()         ``string`` (Read/Get) element typeof(string) from internal buffer
- ###### Class<``T``> ()       ``T`` (Read/Get) element typeof(T) from internal buffer
- ###### Struct<``T``>()       ``T`` (Read/Get) element typeof(T) from internal buffer
- ###### Array<``T``>()      ``T[]`` (Read/Get) element typeof(T[]) from internal buffer
- ###### List<``T``>()   ``List`` (Read/Get) element typeof(List
- ###### BigInteger() ``BigInteger`` (Read/Get) element typeof(BigInteger) from internal buffer
- ###### Bytes()          ``byte[]`` (Read/Get) element typeof(byte[]) from internal buffer

📄 Example

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
    
    var myCharacterInfoClass = primitive.Get.Class();
    var myCharacterArray = primitive.Get.Array();
    var myLogList = primitive.Get.List();
    var myDeviceStruct = primitive.Get.Struct();
    var myTime = primitive.Get.DateTime();
    var myEnum = primitive.Get.Enum();
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
        var loginInfo = primitive.Get.Class();
        
        if (!primitive.IsValid) return; // ignore this
        // login user...
    }
    else if (topic == "get user address")
    {
        var getUserAddressInfo = primitive.Get.Class();
        
        if (!primitive.IsValid) return; // ignore this
        // get user adress...
    }
    ...
    else
    {
        // ignore this. (Topic not found)
    }
    ```

##### Overhead (supported types list)

> Byter overhead information

| Type       | Primitive (overhead + size = total)                      | Writer/Reader (overhead + size = total)                 |
|------------|----------------------------------------------------------|---------------------------------------------------------|
| Bool       | ✔️  (1 + 1 = 2 bytes)                                    | ✔️ (2 + 1 = 3 bytes)                                    |
| Byte       | ✔️  (1 + 1 = 2 bytes)                                    | ✔️ (2 + 1 = 3 bytes)                                    |
| SByte      | ✔️  (1 + 2 = 2 bytes)                                    | 🚫                                                      |
| Char       | ✔️  (1 + 2 = 3 bytes)                                    | ✔️ (2 + 2 = 4 bytes)                                    |
| Short      | ✔️  (1 + 2 = 3 bytes)                                    | ✔️ (2 + 2 = 4 bytes)                                    |
| UShort     | ✔️  (1 + 2 = 3 bytes)                                    | ✔️ (2 + 2 = 4 bytes)                                    |
| Int        | ✔️  (1 + 4 = 5 bytes)                                    | ✔️ (2 + 4 = 6 bytes)                                    |
| UInt       | ✔️  (1 + 4 = 5 bytes)                                    | ✔️ (2 + 4 = 6 bytes)                                    |
| Float      | ✔️  (1 + 4 = 5 bytes)                                    | ✔️ (2 + 4 = 6 bytes)                                    |
| Enum       | ✔️  (1 + 4 = 5 bytes)                                    | 🚫                                                      |
| Long       | ✔️  (1 + 8 = 9 bytes)                                    | ✔️ (2 + 8 = 10 bytes)                                   |
| ULong      | ✔️  (1 + 8 = 9 bytes)                                    | ✔️ (2 + 8 = 10 bytes)                                   |
| Double     | ✔️  (1 + 8 = 9 bytes)                                    | ✔️ (2 + 8 = 10 bytes)                                   |
| DateTime   | ✔️  (1 + 8 = 9 bytes)                                    | 🚫                                                      |
| Decimal    | ✔️  (1 + 16 = 17 bytes)                                  | 🚫                                                      |
| String     | ✔️  (5 + ? = +5 bytes) *UTF8                             | ✔️ (6 + ? = +6 bytes)                                   |
| Class      | ✔️  (2 + 0 = 2 bytes)                                    | 🚫                                                      |
| Struct     | ✔️  (2 + 0 = 2 bytes)                                    | 🚫                                                      |
| Array      | ✔️  (3 + ? = +3 bytes)  *Max. 65535                      | 🚫                                                      |
| List       | ✔️  (3 + ? = +3 bytes)  *Max. 65535                      | 🚫                                                      |
| BigInteger | ✔️  (3 + ? = +3 bytes)                                   | 🚫                                                      |
| Bytes      | ✔️  (5 + ? = +5 bytes) *Max. 4.294.967.295 *(~4billions) | ✔️ (6 + ? = +6 bytes) *Max. 2.147.483.647 *(~2billions) |

### Encoding Extension
```csharp
using Byter;
```

- Global Default Encoding [(source code spec)](https://github.com/alec1o/Byter/blob/main/src/src/extension/StringExtension.cs#L8)
   ```csharp
   // update global defaut encoding. Default is UTF8
   StringExtension.Default = Encoding.Unicode; // Unicode is UTF16
   ```

- Convert string to byte[]
    ```csharp
    // using global encoding (*UTF8)
    byte[] username  = "@alec1o".GetBytes(); 
    
    // using UNICODE (*UTF16) encoding
    byte[] message = "Hello 👋 World 🌎".GetBytes(Encoding.Unicode); 
    
    // using UTF32 encoding
    string secreatWord = "I'm not human, I'm  a concept.";
    byte[] secreat = secreatWord.GetBytes(Encoding.UTF32);
    ```

- Convert byte[] to string
    ```csharp
    // using global encoding (*UTF8)
    string username  = new byte[] { ... }.GetString(); 
    
    // using UNICODE (*UTF16) encoding
    string message = new byte[] { ... }.GetString(Encoding.Unicode); 
    
    // using UTF32 encoding
    byte[] secreat = new byte[] { ... };
    string secreatWord = secreat.GetString(Encoding.UTF32);
    ```

- Capitalize string
    ```rb
    string name = "alECio furanZE".ToCapitalize();
    # Alecio Furanze
    
    string title = "i'M noT humAn";
    title = title.ToCapitalize();
    # I'm Not Human
    ```

- UpperCase string
    ```rb
    string name = "alECio furanZE".ToUpperCase();
    # ALECIO FURANZE
    
    string title = "i'M noT humAn";
    title = title.ToUpperCase();
    # I'M NOT HUMAN
    ```

- LowerCase string
    ```rb
    string name = "ALEciO FUraNZE".ToLowerCase();
    # alecio furanze
    
    string title = "i'M Not huMAN";
    title = title.ToLowerCase();
    # i'm not human
    ```

!Content removed: [Need better documentation? READ THIS IN GITHUB ___(click me)___](https://github.com/alec1o/Byter)

