using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.ResponseCodes
{
    public enum ResponseCode
    {
        Success = 1,
        InvalidCredentials = 2,
        ServerError = 3,
        InvalidThumbnail = 4,
        InvalidDemoVideoFile = 5,
        ErrorInsertingProject = 6,
        InvalidProjectId = 7,
        ErrorDeletingProject = 8,
        ErrorDownloadingFile = 9,
        NotFound = 404
    }
}
