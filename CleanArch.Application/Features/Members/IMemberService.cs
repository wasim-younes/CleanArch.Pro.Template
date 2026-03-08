using CleanArch.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Features.Members
{
    public interface IMemberService
    {
        // The "Contract" for getting a single member
        Task<Result<MemberDto>> GetMemberByIdAsync(int id);

        // The "Contract" for getting all members
        Task<Result<IEnumerable<MemberDto>>> GetAllMembersAsync();

        // The "Contract" for creating a member
        Task<Result<int>> CreateMemberAsync(string firstName, string lastName, string email);
    }
}
