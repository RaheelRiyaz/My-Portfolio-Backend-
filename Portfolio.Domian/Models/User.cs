using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class User : BaseEntity
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ResetCode { get; set; } 
        public DateTime? ResetExpiry { get; set; } 
    }
}
