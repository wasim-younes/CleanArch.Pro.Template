using CleanArch.Domain.Enums;
using CleanArch.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace CleanArch.Domain.Entities
{
    public class Member : BaseEntity
    {
        // 1. Properties
        public string FirstName { get; private set; } = string.Empty;
        public string LastName { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public PriorityLevel Tier { get; private set; }
        public Address? HomeAddress { get; private set; }

        // 2. Constructor (Ensures the object is valid when created)
        public Member(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Tier = PriorityLevel.Low; // Default tier
        }

        // 3. Logic/Methods (The "Brain" of the entity)
        public string FullName => $"{FirstName} {LastName}";

        public void UpdateAddress(Address newAddress)
        {
            HomeAddress = newAddress;
            // Logic: You could add a 'LastModified' update here
        }

        public void UpgradeTier()
        {
            if (Tier < PriorityLevel.Urgent)
            {
                Tier++;
            }
        }
    }
}
