using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PCP.Data.Concrete.Config;
using PCP.Entities.Concrete;
using PCP.Entities.Concrete.Identity;
using PCP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Data.Concrete.DbContexts
{
    public class ProductCatalogDbContext : IdentityDbContext<User, Role, Guid>
    {
        public ProductCatalogDbContext(DbContextOptions<ProductCatalogDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }


        public override int SaveChanges()
        {
           // AddTimestamps();
            return base.SaveChanges();
        }

        //private void AddTimestamps()
        //{
        //    //var headers = _httpContextAccessor.HttpContext.Request.Headers;
        //    //var useri2d = Guid.Parse(headers.FirstOrDefault(x => x.Key == "userid").Value);
        //    var entities = ChangeTracker.Entries().Where(x => (x.Entity is BaseEntity ) && (x.State == EntityState.Added || x.State == EntityState.Modified));
        //    foreach (var entity in entities)
        //    {
        //        Guid userid = Guid.Empty;
        //        try
        //        {
        //            //userid = Guid.Parse(_httpContextAccessor.HttpContext.User.Claims.First(t => t.Type == "UserId").Value);
        //        }
        //        catch (Exception)
        //        {
        //            try
        //            {
        //               // userid = Guid.Parse(_httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "UserId").Value);
        //            }
        //            catch (Exception)
        //            {
        //                try
        //                {
        //                    //userid = Guid.Parse(_httpContextAccessor.HttpContext.Request.Headers.FirstOrDefault(x => x.Key == "userid").Value);
        //                }
        //                catch (Exception)
        //                {
        //                }
        //            }
        //        }
        //        //TODO

        //        if (entity.State == EntityState.Added)
        //        {
        //            ((BaseEntity)entity.Entity).CreatedDate = DateTime.Now;
        //          //  ((BaseEntity)entity.Entity).UserCreated = userid;
        //            ((BaseEntity)entity.Entity).IsActive = true;
        //            ((BaseEntity)entity.Entity).IsDeleted = false;
        //        }
        //            ((BaseEntity)entity.Entity).ModifiedDate = DateTime.Now;
        //        //((BaseEntity)entity.Entity).UserModified = userid;

        //    }
        //    }
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            //modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }
}
