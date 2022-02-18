using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Data.Concrete.DbContexts
{
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}
