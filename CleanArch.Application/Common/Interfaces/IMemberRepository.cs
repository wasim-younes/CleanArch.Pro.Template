using CleanArch.Application.Common.Models;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Common.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member?> GetByIdAsync(int id);
        Task<IEnumerable<Member>> GetAllAsync();

        // Use the Entity here, not raw strings!
        Task AddAsync(Member member);

        Task UpdateAsync(Member member);
        Task DeleteAsync(Member member);
    }
}
