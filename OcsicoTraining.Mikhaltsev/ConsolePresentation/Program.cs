using System;
using System.Threading.Tasks;
using EntityModels;
using Microsoft.Extensions.DependencyInjection;
using ShopBLL.Services.Contracts;
using ViewModels;

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

            var productService = serviceProvider.GetService<IProductService>();

            var image = new Image { Name = "ImageName", Data = "ImageData" };

            var productViewModel = new CreateProductViewModel
            {
                Name = "PrNameNew",
                Description = "PrDescriptionNew",
                Price = 1200,
                SelectedParentId = Guid.Parse("d0b1462d-d337-4d86-c818-08d7c0fe26fe"),
                Image = image
            };

            await productService.CreateAsync(productViewModel);
        }
    }
}
