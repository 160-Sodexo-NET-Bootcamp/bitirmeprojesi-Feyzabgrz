using PCP.Entities.Concrete.Identity;
using PCP.Shared.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PCP.Entities.Enums.AppEnums;

namespace PCP.Entities.Concrete
{
    public class Product : BaseEntity
    {
     
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Brand { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public bool IsOfferable { get; set; }
        public bool IsSold { get; set; }
        public ProductStatus Status { get; set; }
    }
}
