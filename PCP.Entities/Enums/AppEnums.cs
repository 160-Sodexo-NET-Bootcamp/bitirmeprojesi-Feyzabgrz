using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCP.Entities.Enums
{
    public class AppEnums
    {
        public enum ProductStatus
        {
            [Display(Description = "Satılabilir")]
            Salable = 100,
            [Display(Description = "Kaldırıldı")]
            Removed = 200,
            [Display(Description = "Satıldı")]
            Sold = 400,
        }

        public enum LogTypes
        {
            [Display(Description = "Başarılı")]
            Success = 1,
            [Display(Description = "Başarısız")]
            UnSuccess = 2,
            [Display(Description = "Hata")]
            Error = 3,
           
        }
    }
}
