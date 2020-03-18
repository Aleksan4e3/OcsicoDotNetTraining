using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ShopBLL.Services.Contracts;

namespace ShopBLL.Services
{
    public class FileConverter : IFileConverter
    {
        private readonly IHostingEnvironment hostingEnvironment;

        public FileConverter(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public string ToBase64(string path)
        {
            var bytes = File.ReadAllBytes(hostingEnvironment.WebRootPath + path);

            return Convert.ToBase64String(bytes);
        }

        public async Task<string> SaveFileAsync(IFormFile uploadedFile)
        {
            var path = string.Empty;

            if (uploadedFile != null)
            {
                path = "/Images/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(hostingEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }
            }

            return path;
        }
    }
}
