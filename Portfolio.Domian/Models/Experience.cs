using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class Experience : BaseEntity
    {
        public string CopmanyName { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Description { get; set; } = null!;
        public string TechSet { get; set; } = null!;
    }
}
