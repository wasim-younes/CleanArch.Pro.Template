using CleanArch.Application.Features.Members;
using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Common.Mappings
{
    public static class MemberMapper
    {
        // 2. The method MUST be static and use 'this' before the type
        public static MemberDto ToDto(this Member member)
        {
            return new MemberDto(
                member.Id,
                member.FullName,
                member.Email,
                member.Tier.ToString(),
                member.HomeAddress != null
                    ? $"{member.HomeAddress.Street}, {member.HomeAddress.City}"
                    : "No Address"
            );
        }
    }
}
