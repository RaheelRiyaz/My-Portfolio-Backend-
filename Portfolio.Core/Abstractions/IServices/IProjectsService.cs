using Portfolio.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Abstractions.IServices
{
    public interface IProjectsService
    {
        Task<DataResponse<bool>> AddProject(ProjectRequest model);
        Task<DataResponse<List<ProjectResponse>>> ViewProjects();
        Task<DataResponse<bool>> DeleteProject(Guid id);
        Task<DataResponse<FileResponse>> DownloadFile(string path);
    }
}
