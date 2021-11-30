using FundProjects.Data;
using FundProjects.DTOs;
using FundProjects.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjects.Service
{
    public class ProjectCreatorService : IProjectCreatorService
    {
        private readonly FundContext _fundContext;

        public string Reward { get; private set; }

        public ProjectCreatorService(FundContext context)
        {
            _fundContext = context;
        }

        public async Task<ProjectCreatorDto> AddProjectCreator(ProjectCreatorDto dto)
        {
            var projectCreator = new ProjectCreator()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };
            _fundContext.ProjectCreators.Add(projectCreator);

            foreach (var rewardPackageDto in dto.RewardpackagesDtos)
            {
                var rewardPackage = new RewardPackage()
                {
                    FundAmount = rewardPackageDto.FundAmount,
                    Reward = rewardPackageDto.Reward
                };

                _fundContext.RewardPackage.Add(rewardPackage);
                _fundContext.ProjectCreatorRewardPackages.Add(
                    new ProjectCreatorRewardPackage
                    {
                        ProjectCreator = projectCreator,
                        RewardPackage = rewardPackage
                    }
                ); ;

            }
            await _fundContext.SaveChangesAsync();

            return projectCreator.Convert();
        }

        public async Task<ProjectCreatorDto> AddProjectCreatorWithRewardsPackages(ProjectCreatorDto dto)
        {
            var projectCreatorRewardPackages = _fundContext.ProjectCreatorRewardPackages.Find();


            var projectCreator = new ProjectCreator()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber
            };

            _fundContext.ProjectCreators.Add(projectCreator);
            await _fundContext.SaveChangesAsync();

            return projectCreator.Convert();
        }

        public async Task<ProjectCreatorDto> GetProjectCreator(int id)
        {
            var projectCreator = await _fundContext.ProjectCreators.SingleOrDefaultAsync(a => a.Id == id);
            return projectCreator.Convert();

        }

        public async Task<List<ProjectCreatorDto>> GetProjectCreators()
        {
            return await _fundContext.ProjectCreators
               .Select(p => p.Convert())
               .ToListAsync();
        }

        public async Task<ProjectCreatorDto> Update(int projectCreatorId, ProjectCreatorDto dto)
        {
            ProjectCreator projectCreator = await _fundContext.ProjectCreators
              .SingleOrDefaultAsync(pc => pc.Id == projectCreatorId);

            if (projectCreator is null) throw new NotFoundException("The project Creator id is invalid or has been removed.");
            if (dto.FirstName is null || dto.LastName is null || dto.Email is null) {
                throw new ArgumentException("Project creator must have first name,last name and email.");

            }

            projectCreator.FirstName = dto.FirstName;
            projectCreator.LastName = dto.LastName;
            projectCreator.Email = dto.Email;
            await _fundContext.SaveChangesAsync();
            return projectCreator.Convert();
        }

        public async Task<ProjectCreatorDto> Replace(int projectCreatorId, ProjectCreatorDto dto)
        {
            ProjectCreator projectCreator = await _fundContext.ProjectCreators
                .SingleOrDefaultAsync(pc => pc.Id == projectCreatorId);

            if (projectCreator is null) throw new NotFoundException("The project creator id is invalid or has been removed.");

            projectCreator.FirstName = dto.FirstName;
            projectCreator.LastName = dto.LastName;
            projectCreator.Email = dto.Email;

            await _fundContext.SaveChangesAsync();

            return projectCreator.Convert();
        }

        public async Task<bool> Delete(int projectCreatorId)
        {
            ProjectCreator projectCreator = await _fundContext.ProjectCreators.SingleOrDefaultAsync(pc => pc.Id == projectCreatorId);
            if (projectCreator is null) return false;
            _fundContext.Remove(projectCreator);

            await _fundContext.SaveChangesAsync();
            return true;
        }
    }
}
