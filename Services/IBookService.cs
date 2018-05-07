using System;

namespace Books.Services
{
    public interface IBookService : IDisposable
    {
        void ReadBooks();
        void ReadAllBooks();
    }
}
