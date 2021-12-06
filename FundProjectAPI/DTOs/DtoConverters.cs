﻿using FundProjectAPI.DTOs;
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
            if (projectCreator is null) return null;

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
            if (projectCreatorDto is null) return null;

            return new ProjectCreator()
            {
                Id = projectCreatorDto.Id,
                FirstName = projectCreatorDto.FirstName,
                LastName = projectCreatorDto.LastName,
                Email = projectCreatorDto.Email,
                PhoneNumber = projectCreatorDto.PhoneNumber
            };
        }

        public static ProjectDto Convert(this Project project)
        {
            if (project is null) return null;

            return new ProjectDto()
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                Goal = project.Goal,
                Category = project.Category,
                GoalGained = project.GoalGained
            };
        }

        public static Project Convert(this ProjectDto projectDto)
        {
            if (projectDto is null) return null;

            return new Project()
            {
                Title = projectDto.Title,
                Goal = projectDto.Goal,
                Category = projectDto.Category,
            };
        }

        public static RewardPackage Convert(this RewardPackageDto rewardPackageDto)
        {
            if (rewardPackageDto is null) return null;

            return new RewardPackage()
            {
                FundAmount = rewardPackageDto.FundAmount,
                Reward = rewardPackageDto.Reward
            };
        }

        public static BackerDto Convert(this Backer backer)
        {
            if (backer is null) return null;

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

        








    }







}
