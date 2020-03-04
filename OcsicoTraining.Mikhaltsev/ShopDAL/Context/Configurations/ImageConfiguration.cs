using EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ShopDAL.Context.Configurations
{
    public class ImageConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("Images");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Data)
                .IsRequired();

            builder.HasMany(x => x.Articles)
                .WithOne(x => x.Image)
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Image)
                .HasForeignKey(x => x.ImageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
