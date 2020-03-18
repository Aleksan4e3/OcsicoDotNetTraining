using System;

namespace EntityModels
{
    public class Article : IBaseEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}
