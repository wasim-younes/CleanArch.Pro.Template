using CleanArch.Application.Common.Interfaces;
using CleanArch.Application.Common.Mappings;
using CleanArch.Application.Common.Models;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Features.Members
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        // We inject the Repository interface here
        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public async Task<Result<MemberDto>> GetMemberByIdAsync(int id)
        {
            var member = await _memberRepository.GetByIdAsync(id);

            if (member == null)
                return Result<MemberDto>.Failure("Member not found.");s

            // Using our manual mapper (ToDto)
            return Result<MemberDto>.Success(member.ToDto());
        }

        public async Task<Result<IEnumerable<MemberDto>>> GetAllMembersAsync()
        {
            var members = await _memberRepository.GetAllAsync();

            var dtos = members.Select(m => m.ToDto());

            return Result<IEnumerable<MemberDto>>.Success(dtos);
        }

        public async Task<Result<int>> CreateMemberAsync(string firstName, string lastName, string email)
        {
            // 1. Logic: Check if email is already taken (Optional but professional)
            // 2. Create the Domain Entity
            var member = new Member(firstName, lastName, email);

            // 3. Save to Database through Repository
            await _memberRepository.AddAsync(member);

            // 4. Return the New ID
            return Result<int>.Success(member.Id);
        }
    }
}
