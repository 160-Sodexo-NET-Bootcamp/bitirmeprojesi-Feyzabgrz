using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Entities.Concrete.Identity
{
    public class User : IdentityUser<Guid>
    {

        //Bir userın birden fazla ürünü olabilir

        //public string UserName { get; set; }
        //public string Email { get; set; }
        //public byte[] PasswordHash { get; set; }

        public ICollection<Product> Products { get; set; }




    }
}
