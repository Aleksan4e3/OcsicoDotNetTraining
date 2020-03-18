using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels
{
    public class CreateArticleViewModel
    {
        [Display(Name = "ArticleName")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Image")]
        public IFormFile ImageUrl { get; set; }
    }
}
