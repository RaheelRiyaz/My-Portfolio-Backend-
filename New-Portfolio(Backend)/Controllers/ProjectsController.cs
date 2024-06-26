using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Core;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Core.DTO;
using Portfolio.Core.ResponseCodes;

namespace New_Portfolio_Backend_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController (IProjectsService projectsService) : ControllerBase
    {

        [HttpPost("add")]
        public async Task<DataResponse<bool>> AddProject([FromForm] ProjectRequest model) =>
            await projectsService.AddProject(model);


        [HttpGet]
        public async Task<DataResponse<List<ProjectResponse>>> ViewProjects() =>
            await projectsService.ViewProjects();


        [HttpDelete("{id:guid}")]
        public async Task<DataResponse<bool>> DeleteProject(Guid id) =>
            await projectsService.DeleteProject(id);


        [HttpPost("download-file")]
        public async Task<ActionResult> DownloadFile(FileRequest model)
        {
            var file = await projectsService.DownloadFile(model.Path);

            if (file.Code == ResponseCode.Success)
                return File(file.Result!.Bytes, file.Result.ContentType, file.Result.FileName);

            else return Ok(file);
        }
    }
}
