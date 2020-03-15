using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Display(Name = "Текст")]
        public string Text { get; set; }

        [Display(Name = "Изображение")]
        public string ImageBase64 { get; set; }
    }
}
