using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Books.Modules;
using Books.Services;
using Books.Utilities;

namespace Books.Applicattion
{
    class Program
    {
        static void Main(string[] args)
        {
            AppModule AppModule = new AppModule();
            IContainer Container = AppModule.BuildContainer();

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IBookService bookService = scope.Resolve<IBookService>();
                bookService.ReadBooks();
            }

            using (ILifetimeScope scope = Container.BeginLifetimeScope())
            {
                IPersonService personService = scope.Resolve<IPersonService>();
                personService.PrintList();
            }

            Console.WriteLine("TaskUtil Test ---");
            var tasks = new List<Task<int>>();

            TaskUtils taskUtils = new TaskUtils(Container);
            Task<int> CalcTask = taskUtils.GetCalcAsync();
            Task<int> PersonTask = taskUtils.GetPersonAsync();
            
            tasks.Add(CalcTask);
            tasks.Add(PersonTask);
            
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine($"GetCalcAsync result={CalcTask.Result}");
            Console.WriteLine($"GetPersonAsync result={PersonTask.Result}");

            SongUtils songUtils = new SongUtils();
            songUtils.GetSongs();
            
            
            Container.Dispose();
        }
    }

}
