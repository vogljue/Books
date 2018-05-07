using Autofac.Extras.NLog;
using System;
using Books.Utilities;

namespace Books.Services
{
    public class BookService : IBookService
    {
        private readonly ILogger _logger;
        private BookUtils bookUtils;

        public BookService(ILogger logger)
        {
            _logger = logger;
            _logger.Info("Inizializing BookService");
            bookUtils = new BookUtils();        
        }

        public void Dispose()
        {
            _logger.Info("Dispose on BookService");
            Console.WriteLine("Dispose on BookService");
            bookUtils.Dispose();
        }

        public void ReadBooks()
        {
            _logger.Info("ReadBooksDTO");
            bookUtils.ReadBooksDTO();
        }

        public void ReadAllBooks()
        {
            _logger.Info("ReadAllBooks");
            bookUtils.ReadAllBooks();
        }
    }
}
