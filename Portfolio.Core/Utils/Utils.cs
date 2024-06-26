
using BCrypt.Net;
using Microsoft.AspNetCore.Http;
using Portfolio.Core.DTO;
using Portfolio.Core.Exceptions;
using Portfolio.Core.ResponseCodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.UtilsMehtods
{
    public static class Utils
    {
        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt();

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            bool passwordMatch = BCrypt.Net.BCrypt.Verify(password, hashedPassword);

            return passwordMatch;
        }


        public static void ValidateFile(IFormFile file, ResponseCode code, string ? message,params string[] extensions)
        {
            var extension = Path.GetExtension(file.FileName);

            var isValid = extensions.Contains(extension.ToLower());

            if (!isValid)
                throw new AppException(code,message ?? "");
        }

        public static FileResponse GenerateFileResponse(byte[] bytes, string filePath)
        {
            var fileName = Path.GetFileName(filePath);

            var reg = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(Path.GetExtension(fileName).ToLower());
            string contentType = "application/unknown";

            if (reg != null)
            {
                string registryContentType = reg.GetValue("Content Type") as string;

                if (!String.IsNullOrWhiteSpace(registryContentType))
                {
                    contentType = registryContentType;
                }
            }

            var file = new FileResponse
            {
                ContentType = contentType,
                Bytes = bytes,
                FileName = fileName
            };

            return file;
        }
    }
}
