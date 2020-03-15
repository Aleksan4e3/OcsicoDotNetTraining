using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace ViewModels
{
    public class CreateArticleViewModel
    {
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Display(Name = "Изображение")]
        public IFormFile ImageUrl { get; set; }
    }
}
