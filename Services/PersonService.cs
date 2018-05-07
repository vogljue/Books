using Autofac.Extras.NLog;
using System;
using Books.Utilities;

namespace Books.Services
{
    public class PersonService : IPersonService
    {
        private readonly ILogger _logger;

        public PersonService(ILogger logger)
        {
            _logger = logger;
            _logger.Info("Initializing PersonService");
        }

        public void Dispose()
        {
            _logger.Info("Dispose on PersonService");
            Console.WriteLine("Dispose on PersonService");;
        }

        public void PrintList()
        {
            _logger.Info("PrintList");
            PersonUtils.PrintList();
        }
    }
}
