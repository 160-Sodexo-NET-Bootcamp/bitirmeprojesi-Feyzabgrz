using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PCP.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Data.Concrete.Config
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.CategoryName).IsRequired();
            builder.Property(c => c.CategoryName).HasMaxLength(200);
           // builder.HasOne<Category>(c => c.Category).WithMany().HasForeignKey(c => c.CategoryId);


            //builder.HasData(new Category
            //{
            //    Id = new System.Guid(),
            //    /*Category adı falan felan*/


            //});
        }
    }
}
