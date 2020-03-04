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
        private static async Task Main()
        {
            await RunTask();
            Console.ReadKey();
        }

        private static async Task RunTask()
        {
            var serviceProvider = DependencyResolver.GetServiceProvider();

            var dataContext = serviceProvider.GetService<IDataContext>();
            var imageRepository = serviceProvider.GetService<IImageRepository>();
            var articleRepository = serviceProvider.GetService<IArticleRepository>();

            //await imageRepository.AddAsync(new Image { Name = "testText", Data = "testTitle" });
            //await articleRepository.AddAsync(new Article
            //{
            //    Text = "ArtText",
            //    Title = "ArtTitle",
            //    ImageId = Guid.Parse("96f2d7c1-ee34-4a84-c9b7-08d7c0865715")
            //});
            await articleRepository.RemoveAsync(Guid.Parse("d1e91dec-07ea-4307-0b3d-08d7c08c3b09"));
            await dataContext.SaveChangesAsync();
        }
    }
}
