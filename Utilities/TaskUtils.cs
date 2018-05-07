using System;
using System.Threading.Tasks;
using Autofac;
using Books.Services;

namespace Books.Utilities
{
    public class TaskUtils
    {
        IContainer Container;
        
        public TaskUtils(IContainer Container)
        {
            this.Container = Container;
        }
        
        public async Task<int> GetCalcAsync()
        {
            int result = 0;

            for (int i = 0; i < 20; i++)
            {
                result += i;
                Console.WriteLine("GetCalcAsync loop...");
                await Task.Delay(200);
            }

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IBookService bookService = scope.Resolve<IBookService>();
                bookService.ReadAllBooks();
            }

            return result;
        }

        public async Task<int> GetPersonAsync()
        {
            int result = 0;

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IPersonService personService = scope.Resolve<IPersonService>();
                personService.PrintList();
            }
            
            await Task.Delay(200);
            return result;
        }
    }
}
