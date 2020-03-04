using System;

namespace EntityModels
{
    public class Article : IEntityModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public Guid ImageId { get; set; }
        public virtual Image Image { get; set; }
    }
}
