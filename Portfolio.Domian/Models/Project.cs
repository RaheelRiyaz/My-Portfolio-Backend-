using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Domain.Models
{
    public class Project : BaseEntity
    {
        public string Thumbnail { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string GithubLink { get; set; } = null!;
        public string? LiveLink { get; set; } = null!;
        public string Techs { get; set; } = null!;
        public string? DemoVideoLink { get; set; } = null!;
    }
}
