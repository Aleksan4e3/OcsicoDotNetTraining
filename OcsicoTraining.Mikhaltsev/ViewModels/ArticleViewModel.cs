using System;
using System.ComponentModel.DataAnnotations;

namespace ViewModels
{
    public class ArticleViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "ArticleName")]
        public string Title { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Image")]
        public string ImageBase64 { get; set; }
    }
}
