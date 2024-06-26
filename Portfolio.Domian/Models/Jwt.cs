using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class Jwt
    {
        public int Expiry { get; set; }
        public string Secret { get; set; } = null!;
    }
}
