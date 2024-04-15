using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Company
    {
        public int Id { get; set; }

        public String? Name { get; set; }

        public String? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; } = null;

        public ICollection<CompanyPromotion>? CompanyPromotion { get; set; }



    }
}
