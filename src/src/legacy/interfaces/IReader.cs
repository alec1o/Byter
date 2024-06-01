using System.Text;

namespace Byter
{
    internal interface IReader
    {
        int Length { get; }
        int Position { get; }
        bool Success { get; }

        T Read<T>();
        T Read<T>(Encoding encode);
        void Seek(int position);
    }
}