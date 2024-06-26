using Microsoft.AspNetCore.Http;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Core.Exceptions;
using Portfolio.Core.ResponseCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public class StorageService
        (
        string webrootPath
        ) : IStorageService
    {
        public async Task<string> DeleteFileAsync(string filePath)
        {
            await Task.Run(() => File.Delete(Path.Combine(webrootPath, filePath)));
            return filePath;
        }

        public async Task<List<string>> DeleteFilesAsync(params string[] filePaths)
        {
            var paths = new List<string>();
            foreach (var path in filePaths)
            {
                paths.Add(await DeleteFileAsync(path));
            }
            return paths;
        }

        public async Task<(byte[],string)> DownloadFile(string path)
        {
            var fullPath = Path.Combine(webrootPath, path);

            if (!File.Exists(fullPath))
                throw new AppException(ResponseCode.NotFound);

            var bytes = await Task.Run(() =>File.ReadAllBytes(fullPath));

            return (bytes, fullPath);
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {
            var fileName = string.Concat(Guid.NewGuid(),file.FileName);
            var filePath = Path.Combine(GetPhysicalPath(), fileName);
            using var fileStream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(fileStream);
            return Path.Combine(GetVirtualPath(),fileName);
        }

        public async Task<List<string>> SaveFileAsync(IFormFileCollection files)
        {
            List<string> paths = new List<string>();
            foreach (var file in files)
            {
                paths.Add(await SaveFileAsync(file));
            }

            return paths;
        }

        public async Task<List<string>> SaveFilesAsync(params IFormFile[] files)
        {
            List<string> paths = new List<string>();
            foreach (var file in files)
            {
                paths.Add(await SaveFileAsync(file));
            }
            return paths;
        }

        private string GetPhysicalPath()
        {
            var path = Path.Combine(webrootPath, GetVirtualPath());

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path;
        }

        private string GetVirtualPath() => "Files";
    }
}
