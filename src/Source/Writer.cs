using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Byter.Core.Interface;

namespace Byter
{
    public class Writer : IWriter, IDisposable
    {
        private List<byte[]> _list;
        private int _length;

        public int Length => _length;

        #region Builder

        public Writer()
        {
            _list = new List<byte[]>();
        }

        public Writer(byte[] buffer)
        {
            _list = new List<byte[]>();
            _list.Add(buffer);
        }

        public Writer(Writer writer)
        {
            _list = new List<byte[]>();
            _list.Add(writer.GetBytes());
            _length = writer.Length;
        }

        #endregion

        #region Other

        public byte[] GetBytes()
        {
            return _list.SelectMany(x => x).ToArray();
        }

        public List<byte> GetList()
        {
            return _list.SelectMany(x => x).ToList();
        }

        public void Clear()
        {
            _list.Clear();
            _length = 0;
        }

        #endregion

        #region Write

        public void Write(byte value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, new byte[1] { value });
        }

        public void Write(bool value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, new byte[1] { (byte)(value ? 1 : 0) });
        }

        public void Write(byte[] value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value.Length), value);
        }

        public void Write(short value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(ushort value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(int value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(uint value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(long value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(ulong value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(float value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(double value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(char value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value));
        }

        public void Write(string value)
        {
            Write(value, Encoding.UTF8);
        }

        public void Write(string value, Encoding encoding)
        {
            char prefix = GetPrefix(value);
            byte[] bytes = encoding.GetBytes(value);
            Save(prefix, BitConverter.GetBytes(bytes.Length), bytes);
        }

        public void Write(Float2 value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, BitConverter.GetBytes(value.X), BitConverter.GetBytes(value.Y));
        }

        public void Write(Float3 value)
        {
            char prefix = GetPrefix(value);
            Save
            (
                prefix,
                BitConverter.GetBytes(value.X),
                BitConverter.GetBytes(value.Y),
                BitConverter.GetBytes(value.Z)
            );
        }

        #endregion

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
                    _list.Clear();
                }

                // Call the appropriate methods to clean up unmanaged resources here.
                // If disposing is false, only the following code is executed.

                // <instance>.Dispose();

                // Note disposing has been done.
                disposed = true;
            }
        }

        ~Writer()
        {
            Dispose(disposing: false);
        }

        #endregion

        private void Save(char prefix, params byte[][] values)
        {
            if (values == null || values.Length <= 0 || values[0] == null || values[0].Length <= 0)
            {
                return;
            }

            #region ADD PREFIX            

            byte[] _prefix = BitConverter.GetBytes(prefix);
            _list.Add(_prefix);
            _length += _prefix.Length;
            
            #endregion
            
            foreach (var value in values)
            {
                _list.Add(value);
                _length += value.Length;
            }
        }

        internal static char GetPrefix(object obj) => GetPrefix(obj.GetType());

        internal static char GetPrefix(Type type)
        {
            if (type == typeof(byte))           /*  byte    */ return 'A';
            else if (type == typeof(byte[]))    /*  byte[]  */ return 'B';
            else if (type == typeof(short))     /*  short   */ return 'C';
            else if (type == typeof(ushort))    /*  ushort  */ return 'D';
            else if (type == typeof(int))       /*  int     */ return 'E';
            else if (type == typeof(uint))      /*  uint    */ return 'F';
            else if (type == typeof(long))      /*  long    */ return 'G';
            else if (type == typeof(ulong))     /*  ulong   */ return 'H';
            else if (type == typeof(float))     /*  float   */ return 'I';
            else if (type == typeof(double))    /*  double  */ return 'J';
            else if (type == typeof(char))      /*  char    */ return 'K';
            else if (type == typeof(string))    /*  string  */ return 'L';
            else if (type == typeof(bool))      /*  bool    */ return 'M';
            else if (type == typeof(Float2))    /*  Float2  */ return 'N';
            else if (type == typeof(Float3))    /*  Float3  */ return 'O';
            else                                /*  null    */ return '0';
        }

    }
}
