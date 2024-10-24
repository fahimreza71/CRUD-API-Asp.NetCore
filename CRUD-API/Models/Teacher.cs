using System;
using System.Collections.Generic;

namespace CRUD_API.Models
{
    public partial class Teacher
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? Designation { get; set; }
        public int? Salary { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
    }
}
