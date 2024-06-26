using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Abstractions.IServices
{
    public interface IStorageService
    {
        Task<string> SaveFileAsync(IFormFile file);
        Task<List<string>> SaveFileAsync(IFormFileCollection files);
        Task<List<string>> SaveFilesAsync(params IFormFile [] files);
        Task<string> DeleteFileAsync(string filePath);
        Task<List<string>> DeleteFilesAsync(params string [] filePaths);
        Task<(byte[], string)> DownloadFile(string path);
    }
}
