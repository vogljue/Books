using System;

namespace Books.Services
{
    public interface IPersonService : IDisposable
    {
        void PrintList();
    }
}
