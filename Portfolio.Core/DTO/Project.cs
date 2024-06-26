using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DTO
{
    public class BaseResponse
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string GithubLink { get; set; } = null!;
        public string? LiveLink { get; set; } = null!;
    }
    public class ProjectRequest : BaseResponse
    {
        public IFormFile Thumbnail { get; set; } = null!;
        public IFormFile? DemoVideo { get; set; }
        public string Techs { get; set; } = null!;
    }

    public class ProjectResponse : BaseResponse
    {
        public string Thumbnail { get; set; } = null!;
        public string? DemoVideoLink { get; set; } = null!;
        public List<string> Techs { get; set; } = null!;
    }
}
