using Portfolio.Core.Abstractions.IRepository;
using Portfolio.Core.Abstractions.IServices;
using Portfolio.Core.DTO;
using Portfolio.Core.Exceptions;
using Portfolio.Core.ResponseCodes;
using Portfolio.Core.UtilsMehtods;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Core.Services
{
    public class ProjectService
        (
        IProjectsRepository repository,
        IStorageService storageService
        ) : IProjectsService
    {
        public async Task<DataResponse<bool>> AddProject(ProjectRequest model)
        {
            try
            {
                var project = await ValidateProjectRequestAndPopulateFields(model);

                var insertedCount = await repository.InsertAsync(project);

                if (insertedCount > 0)
                    return DataResponse<bool>.SuccessResponse(true);

                throw new AppException(ResponseCode.ErrorInsertingProject);
            }
            catch (AppException exception)
            {
                return DataResponse<bool>.ErrorResponse(exception.Code, exception.Info);
            }
            catch
            {
                return DataResponse<bool>.ErrorResponse(ResponseCode.ErrorInsertingProject);
            }

        }

        public async Task<DataResponse<List<ProjectResponse>>> ViewProjects()
        {
            var projects = await repository.FetchAll();

            var response = PopulateProjectResponse(projects);

            return DataResponse<List<ProjectResponse>>.SuccessResponse(response);
        }


        public async Task<DataResponse<bool>> DeleteProject(Guid id)
        {
            try
            {
                var project = await repository.FindOneAsync(id);

                if (project is null)
                    throw new AppException(ResponseCode.InvalidProjectId);

                await DeleteRelatedFiles(project);

                var deletedCount = await repository.RemoveAsync(project);

                if (deletedCount > 0)
                    return DataResponse<bool>.SuccessResponse(true);

                throw new AppException(ResponseCode.ErrorDeletingProject);
            }
            catch (AppException exception)
            {
                return DataResponse<bool>.ErrorResponse(exception.Code, exception.Info);
            }
            catch
            {
                return DataResponse<bool>.ErrorResponse(ResponseCode.ErrorDeletingProject);
            }
        }

        private async Task<Project> ValidateProjectRequestAndPopulateFields(ProjectRequest model)
        {
            Utils.ValidateFile(model.Thumbnail, ResponseCode.InvalidThumbnail, "Invalid thumbnail extension", ".jpg", ".jpeg", ".png", ".img");
            var project = new Project();

            if (model.DemoVideo is not null)
            {
                Utils.ValidateFile(model.DemoVideo, ResponseCode.InvalidDemoVideoFile, "Invalid video extension", ".mp4");
                var paths = await storageService.SaveFilesAsync(model.Thumbnail, model.DemoVideo);
                project.Thumbnail = paths[0];
                project.DemoVideoLink = paths[1];
            }
            else
            {
                var thumbnail = await storageService.SaveFileAsync(model.Thumbnail);
                project.Thumbnail = thumbnail;
            }

            project.Techs = model.Techs;
            project.LiveLink = model.LiveLink;
            project.Description = model.Description;
            project.Title = model.Title;
            project.GithubLink = model.GithubLink;
            return project;
        }


        private List<ProjectResponse> PopulateProjectResponse(IEnumerable<Project> projects)
        {
            ProjectResponse? projectResponse = default;

            var response = new List<ProjectResponse>();

            foreach (var project in projects)
            {
                projectResponse = new ProjectResponse
                {
                    DemoVideoLink = project.DemoVideoLink,
                    Description = project.Description,
                    GithubLink = project.GithubLink,
                    LiveLink = project.LiveLink,
                    Thumbnail = project.Thumbnail,
                    Title = project.Title,
                    Techs = project.Techs.Split(",").ToList()
                };

                response.Add(projectResponse);
            }

            return response;
        }

        private async Task DeleteRelatedFiles(Project project)
        {
            if (project.DemoVideoLink is not null)
            {
                await storageService.DeleteFilesAsync(project.Thumbnail, project.DemoVideoLink);
            }
            else await storageService.DeleteFileAsync(project.Thumbnail);
        }

        public async Task<DataResponse<FileResponse>> DownloadFile(string path)
        {
            try
            {
                var (bytes, filePath) = await storageService.DownloadFile(path);
                var response = Utils.GenerateFileResponse(bytes, filePath);
                return DataResponse<FileResponse>.SuccessResponse(response);
            }
            catch (AppException exception)
            {
                return DataResponse<FileResponse>.ErrorResponse(exception.Code);
            }
            catch
            {
                return DataResponse<FileResponse>.ErrorResponse(ResponseCode.ErrorDownloadingFile);
            }
        }
    }
}
