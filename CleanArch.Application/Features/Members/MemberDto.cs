using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Application.Features.Members
{
    public record MemberDto(
        int Id,
        string FullName,
        string Email,
        string TierName, // Converted from Enum
        string FullAddress // Converted from Value Object
    );
}
