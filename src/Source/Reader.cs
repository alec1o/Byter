using System;
using System.Text;
using Byter.Core.Interface;

namespace Byter
{
    public class Reader : IReader, IDisposable
    {
        private bool _success = true;
        private int _position = 0;
        private byte[] _buffer;

        public int Length => _buffer.Length;
        public int Position => _position;
        public bool Success => _success;

        #region Builder

        // private for IDisposable
        private Reader()
        {
        }

        public Reader(byte[] buffer, int offset = 0)
        {
            Init(buffer, offset);
        }

        public Reader(ref Writer writer)
        {
            if (writer == null || writer.Length <= 0)
            {
                Init(null, 0);
            }
            else
            {
                Init(writer.GetBytes(), 0);
            }
        }

        public Reader(Writer writer)
        {
            if (writer == null || writer.Length <= 0)
            {
                Init(null, 0);
            }
            else
            {
                Init(writer.GetBytes(), 0);
            }
        }

        private void Init(byte[] buffer, int offset)
        {
            if (buffer == null || buffer.Length <= 0 || (buffer.Length - offset) <= 0)
            {
                _buffer = new byte[0];
                return;
            }

            _success = true;
            _buffer = new byte[buffer.Length - offset];
            Buffer.BlockCopy(buffer, offset, _buffer, 0, _buffer.Length);
        }

        #endregion

        #region Other

        public void Seek(int position)
        {
            if (position <= 0) _position = 0;
            else _position = position;
        }

        public T Read<T>()
        {
            try
            {
                char prefix = Writer.GetPrefix(typeof(T));

                // byte
                if (typeof(T) == typeof(byte))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = _buffer[_position];

                    // skip bytes read
                    _position += sizeof(byte);

                    return (T)(object)value;
                }

                // bool
                if (typeof(T) == typeof(bool))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = _buffer[_position];

                    // skip bytes read
                    _position += sizeof(byte);

                    return (T)(object)(value == 1 ? true : false);
                }

                // byte[]
                else if (typeof(T) == typeof(byte[]))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get length of bytes
                    int length = BitConverter.ToInt32(_buffer, _position);
                    _position += sizeof(int);
                    if (length <= 0 || length > (Length - _position))
                    {
                        _success = false;
                        return default;
                    }

                    // get encoded value
                    byte[] value = new byte[length];
                    Buffer.BlockCopy(_buffer, _position, value, 0, value.Length);

                    // skip bytes read
                    _position += value.Length;

                    return (T)(object)value;
                }

                // short
                else if (typeof(T) == typeof(short))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToInt16(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(short);

                    return (T)(object)value;
                }

                // ushort
                else if (typeof(T) == typeof(ushort))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToUInt16(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(ushort);

                    return (T)(object)value;
                }

                // int
                else if (typeof(T) == typeof(int))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToInt32(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(int);

                    return (T)(object)value;
                }

                // uint
                else if (typeof(T) == typeof(uint))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToUInt32(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(uint);

                    return (T)(object)value;
                }

                // long
                else if (typeof(T) == typeof(long))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToInt64(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(long);

                    return (T)(object)value;
                }

                // ulong
                else if (typeof(T) == typeof(ulong))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToUInt64(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(ulong);

                    return (T)(object)value;
                }

                // float
                else if (typeof(T) == typeof(float))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToSingle(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(float);

                    return (T)(object)value;
                }

                // double
                else if (typeof(T) == typeof(double))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToDouble(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(double);

                    return (T)(object)value;
                }

                // char
                else if (typeof(T) == typeof(char))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var value = BitConverter.ToChar(_buffer, _position);

                    // skip bytes read
                    _position += sizeof(char);

                    return (T)(object)value;
                }

                // string
                else if (typeof(T) == typeof(string))
                {
                    return Read<T>(Encoding.UTF8);
                }

                // Float2
                else if (typeof(T) == typeof(Float2))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var x = BitConverter.ToSingle(_buffer, _position);

                    // skip x bytes read
                    _position += sizeof(float);

                    // get encoded value
                    var y = BitConverter.ToSingle(_buffer, _position);

                    // skip y bytes read
                    _position += sizeof(float);

                    return (T)(object)new Float2(x, y);
                }

                // Float3
                else if (typeof(T) == typeof(Float3))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var x = BitConverter.ToSingle(_buffer, _position);

                    // skip x bytes read
                    _position += sizeof(float);

                    // get encoded value
                    var y = BitConverter.ToSingle(_buffer, _position);

                    // skip y bytes read
                    _position += sizeof(float);

                    // get encoded value
                    var z = BitConverter.ToSingle(_buffer, _position);

                    // skip y bytes read
                    _position += sizeof(float);

                    return (T)(object)new Float3(x, y, z);
                }

                // Float4
                else if (typeof(T) == typeof(Float4))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get encoded value
                    var x = BitConverter.ToSingle(_buffer, _position);

                    // skip x bytes read
                    _position += sizeof(float);

                    // get encoded value
                    var y = BitConverter.ToSingle(_buffer, _position);

                    // skip y bytes read
                    _position += sizeof(float);

                    // get encoded value
                    var z = BitConverter.ToSingle(_buffer, _position);

                    // skip y bytes read
                    _position += sizeof(float);


                    // get encoded value
                    var w = BitConverter.ToSingle(_buffer, _position);

                    // skip y bytes read
                    _position += sizeof(float);

                    return (T)(object)new Float4(x, y, z, w);
                }
            }
            catch
            {
                //
            }

            _success = false;
            return default;
        }

        public T Read<T>(Encoding encode)
        {
            try
            {
                char prefix = Writer.GetPrefix(typeof(T));

                // string
                if (typeof(T) == typeof(string))
                {
                    // compare (buffer prefix) to (type prefix)
                    if (!ValidPrefix(prefix)) return default;

                    // get length of bytes
                    int length = BitConverter.ToInt32(_buffer, _position);
                    _position += sizeof(int);
                    if (length <= 0 || length > (Length - _position))
                    {
                        _success = false;
                        return default;
                    }

                    // get encoded value
                    byte[] bytes = new byte[length];
                    Buffer.BlockCopy(_buffer, _position, bytes, 0, bytes.Length);

                    // skip bytes read
                    _position += bytes.Length;

                    // convert bytes to string
                    string value = encode.GetString(bytes);

                    return (T)(object)value;
                }
            }
            catch
            {
                //
            }

            _success = false;
            return default;
        }

        #endregion

        private bool ValidPrefix(char prefix)
        {
            // get char from buffer
            char signal = BitConverter.ToChar(_buffer, _position);

            // compare (buffer prefix) to (type prefix)
            if (prefix == signal)
            {
                // skip bytes read
                _position += sizeof(char);
                return true;
            }

            _success = false;
            return false;
        }


        #region Dispose

        // Track whether Dispose has been called.
        private bool disposed = false;


        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if (!this.disposed)
            {
                // If disposing equals true, dispose all managed and unmanaged resources.
                if (disposing)
                {
                    // Dispose managed resources.

                    // <instance>.Dispose();
                    _buffer = null;
                }

                // Call the appropriate methods to clean up unmanaged resources here.
                // If disposing is false, only the following code is executed.

                // <instance>.Dispose();

                // Note disposing has been done.
                disposed = true;
            }
        }

        ~Reader()
        {
            Dispose(disposing: false);
        }

        #endregion
    }
}