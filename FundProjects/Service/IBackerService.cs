﻿using FundProjects.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FundProjects.Service
{
    public interface IBackerService
    {
        public Task<BackerDto> GetBacker(int id);
        public Task<List<BackerDto>> GetAllBackers();
        public Task<BackerDto> AddBacker(BackerDto dto);
        public Task<List<BackerDto>> Search(string firstName, string lastName, string email);
        public Task<BackerDto> Update(int backerId, BackerDto dto);
        public Task<BackerDto> Replace(int backerId, BackerDto dto);
        public Task<bool> Delete(int backerid);
    }
}