using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ShopBLL.Services.Contracts
{
    public interface IFileConverter
    {
        Task<string> SaveFileAsync(IFormFile uploadedFile);
        string ToBase64(string path);
    }
}
