using FundProjects.DTOs;
using FundProjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjects.Service
{
    public interface IProjectService
    {
        public Task<ProjectDto> GetProject(int id);
        public Task<List<ProjectDto>> GetAllProjects();
        public Task<ProjectDto> AddProject(ProjectDto dto);
        public Task<List<ProjectDto>> Search(string title, ProjectCategory category);
        public Task<ProjectDto> Update(int projectId, ProjectDto dto);
        public Task<ProjectDto> Replace(int projectId, ProjectDto dto);
        public Task<bool> Delete(int projectId);
    }
}
