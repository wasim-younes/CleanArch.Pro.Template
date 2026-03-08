using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArch.Domain.Entities
{
    public class TodoTask : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int MemberId { get; set; } // Foreign Key
    }
}
