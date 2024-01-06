using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using AutoMarket.Domain.Enum;

namespace AutoMarket.Domain.Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Profile Profile { get; set; }
        public Basket Basket { get; set; }
    }
}
