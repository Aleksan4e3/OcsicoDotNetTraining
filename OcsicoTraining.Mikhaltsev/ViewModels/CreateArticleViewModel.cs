using Microsoft.AspNetCore.Http;

namespace ViewModels
{
    public class CreateArticleViewModel
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public IFormFile ImageUrl { get; set; }
    }
}
