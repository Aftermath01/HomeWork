using Threads.Enums;

namespace Threads.Contracts
{
    public interface IWritterFactory
    {
        void Write(AllowedColors color, string message);
    }
}
