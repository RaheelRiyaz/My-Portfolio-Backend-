using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.DTO
{
    public class FileResponse
    {
        public byte[] Bytes { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string ContentType { get; set; } = null!;
    }


    public record FileRequest(string Path);
}
