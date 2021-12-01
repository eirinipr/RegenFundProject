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
    }
}
