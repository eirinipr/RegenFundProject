using FundProjects.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjects.Service
{
    public interface IProjectCreatorService
    {
        public Task<ProjectCreatorDto> AddProjectCreator(ProjectCreatorDto dto);
        public Task<ProjectCreatorDto> GetProjectCreator(int id);
        public Task<List<ProjectCreatorDto>> GetProjectCreators();
        public Task<ProjectCreatorDto> Update(int projectCreatorId, ProjectCreatorDto dto);
        public Task<ProjectCreatorDto> Replace(int projectCreatorId, ProjectCreatorDto dto);
        public Task<bool> Delete(int projectCreatorId);

    }
}
