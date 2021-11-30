﻿using FundProjects.Data;
using FundProjects.DTOs;
using FundProjects.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjects.Service
{
    public class BackerService : IBackerService
    {
        private readonly FundContext _fundContext;
        public BackerService(FundContext context)
        {
            _fundContext = context;
        }
        public async Task<BackerDto> AddBacker(BackerDto dto)
        {
            Backer backer = new Backer()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
            };

            _fundContext.Backers.Add(backer);
            await _fundContext.SaveChangesAsync();

            return backer.Convert();
        }

        public async Task<bool> Delete(int id)
        {
            Backer backer = await _fundContext.Backers.SingleOrDefaultAsync(m => m.Id == id);
            if (backer is null) return false;

            _fundContext.Remove(backer);
            await _fundContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<BackerDto>> GetAllBackers()
        {
            return await _fundContext.Backers.Select(m => m.Convert()).ToListAsync();
        }

        public async Task<BackerDto> GetBacker(int id)
        {
            var backer = await _fundContext.Backers.SingleOrDefaultAsync(a => a.Id == id);
            return backer.Convert();
        }

        public async Task<BackerDto> Replace(int backerId, BackerDto dto)
        {
            Backer backer = await _fundContext.Backers
                .SingleOrDefaultAsync(m => m.Id == backerId);

            if (backer is null) throw new NotFoundException("The backer id is invalid or has been removed.");

            backer.FirstName = dto.FirstName;
            backer.LastName = dto.LastName;
            backer.Email = dto.Email;

            await _fundContext.SaveChangesAsync();

            return backer.Convert();
        }

        public async Task<List<BackerDto>> Search(string firstName, string lastName, string email)
        {
            IQueryable<Backer> results = _fundContext.Backers;

            if (firstName != null)
            {
                results = results.Where(m => m.FirstName.ToLower().Contains(firstName.ToLower()));
            }

            if (lastName != null)
            {
                results = results.Where(m => m.LastName.ToLower().Contains(lastName.ToLower()));
            }

            if (email != null)
            {
                results = results.Where(m => m.Email.ToLower().Contains(email.ToLower()));
            }

            return await results.Select(m => m.Convert()).ToListAsync();
        }

        public async Task<BackerDto> Update(int backerId, BackerDto dto)
        {
            Backer backer = await _fundContext.Backers
                .SingleOrDefaultAsync(m => m.Id == backerId);

            if (backer is null) throw new NotFoundException("The backer id is invalid or has been removed.");

            if (dto.FirstName is not null) backer.FirstName = dto.FirstName;
            if (dto.LastName is not null) backer.LastName = dto.LastName;
            if (dto.Email is not null) backer.Email = dto.Email;

            await _fundContext.SaveChangesAsync();

            return backer.Convert();
        }
    }
}