using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Exceptions
{
    public class UnsupportedTierException : Exception
    {
        public UnsupportedTierException(string tier)
            : base($"The membership tier \"{tier}\" is not supported.")
        {
        }
    }
    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(int id)
            : base($"Member with ID {id} was not found.") { }
    }
}
