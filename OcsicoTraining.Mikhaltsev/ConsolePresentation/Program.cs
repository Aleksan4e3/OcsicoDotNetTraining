using System;
using System.Threading.Tasks;
using EntityModels;
using Microsoft.Extensions.DependencyInjection;
using ShopDAL.Context;
using ShopDAL.Repositories.Contracts;

namespace ConsolePresentation
{
    internal class Program
    {
        private async Task Main()
        {
            await RunTask();
            Console.ReadKey();
        }

        private static async Task RunTask()
        {
            var serviceProvider = DependencyResolver.GetServiceProvider();

            var dataContext = serviceProvider.GetService<IDataContext>();
            var articleRepository = serviceProvider.GetService<IArticleRepository>();

            await articleRepository.AddAsync(new Article { Text = "testText", Title = "testTitle" });
            await dataContext.SaveChangesAsync();
        }
    }
}
