using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Byter.Core.Interface;

namespace Byter
{
    public class Writer : IWriter
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

        public void Write(byte[] value)
        {
            char prefix = GetPrefix(value);
            Save(prefix, value);
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
            Save(prefix, encoding.GetBytes(value));
        }

        #endregion

        
        private void Save(char prefix, byte[] value)
        {
            if (value == null || value.Length <= 0) return;

            byte[] p = BitConverter.GetBytes(prefix);
            
            _list.Add(p);
            _list.Add(value);
            _length += p.Length + value.Length;
        }

        internal static char GetPrefix(object value)
        {
            var type = value.GetType();

            if (type == typeof(byte))       /*  byte    */ return 'A';
            else if(type == typeof(byte[])) /*  byte[]  */ return 'B';
            else if(type == typeof(short))  /*  short   */ return 'C';
            else if(type == typeof(ushort)) /*  ushort  */ return 'D';
            else if(type == typeof(int))    /*  int     */ return 'E';
            else if(type == typeof(uint))   /*  uint    */ return 'F';
            else if(type == typeof(long))   /*  long    */ return 'G';
            else if(type == typeof(ulong))  /*  ulong   */ return 'H';
            else if(type == typeof(float))  /*  float   */ return 'I';
            else if(type == typeof(double)) /*  double  */ return 'J';
            else if(type == typeof(char))   /*  char    */ return 'K';
            else if(type == typeof(string)) /*  string  */ return 'L';
            else                            /*  null    */ return '0';
        }

    }
}