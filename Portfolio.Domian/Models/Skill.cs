using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class Skill : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Icon { get; set; } = null!;
    }
}
