using FundProjectAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectAPI.DTOs
{
    public static class DtoConverters
    {
        public static ProjectCreatorDto Convert(this ProjectCreator projectCreator)
        {
            return new ProjectCreatorDto()
            {
                Id = projectCreator.Id,
                FirstName = projectCreator.FirstName,
                LastName = projectCreator.LastName,
                Email = projectCreator.Email,
                PhoneNumber = projectCreator.PhoneNumber
            };
        }

        public static ProjectCreator Convert(this ProjectCreatorDto projectCreatorDto)
        {
            return new ProjectCreator()
            {
                Id = projectCreatorDto.Id,
                FirstName = projectCreatorDto.FirstName,
                LastName = projectCreatorDto.LastName,
                Email = projectCreatorDto.Email,
                PhoneNumber = projectCreatorDto.PhoneNumber
            };
        }


        public static BackerDto Convert(this Backer backer)
        {
            return new BackerDto()
            {
                Id = backer.Id,
                FirstName = backer.FirstName,
                LastName = backer.LastName
            };
        }

        public static Backer Convert(this BackerDto dto)
        {
            return new Backer()
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }

        public static ProjectDto Convert(this Project project)
        {
            return new ProjectDto()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Category = project.Category,
                ProjectCreatorId = project.ProjectCreatorId
            };

        }

        public static Project Convert(this ProjectDto projectdto)
        {
            return new Project()
            {
                Id = projectdto.Id,
                Title = projectdto.Title,
                Description = projectdto.Description,
                Category = projectdto.Category,
                ProjectCreatorId = projectdto.ProjectCreatorId
            };
        }

        public static RewardPackage Convert(this RewardPackageDto dto)
        {
            return new RewardPackage()
            {
                FundAmount = dto.FundAmount,
                Reward = dto.Reward

            };

        }








    }







}
