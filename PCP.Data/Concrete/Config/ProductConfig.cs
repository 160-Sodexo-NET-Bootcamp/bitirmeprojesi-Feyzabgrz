using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCP.Entities.Concrete;
using PCP.Entities.Concrete.Identity;

namespace PCP.Data.Concrete.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {

        /*Bizim veritabanına gidecek nesnelerimizin ayarlarını ve özelliklerini belirlediğimiz 
         bölüm
        fluent apı ler ile
        profesyonel projelerde data annotatitons kullanılmaz*/

        /*Haskey bunun bir primary key alanı varmı*/
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(c => c.Id);

            /*Identity alanımın eklendikçe buraya bir değer oluştur*/
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description).IsRequired();
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Color).HasMaxLength(500);
            builder.Property(c => c.Brand).HasMaxLength(500);
            builder.Property(c => c.IsOfferable).HasDefaultValue(false);
            builder.Property(c => c.IsSold).HasDefaultValue(false);
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)");
            builder.HasOne<Category>(c => c.Category).WithMany().HasForeignKey(c => c.CategoryId);
            builder.HasOne<User>(c => c.User).WithMany().HasForeignKey(c => c.UserId);


        }
    }
}
