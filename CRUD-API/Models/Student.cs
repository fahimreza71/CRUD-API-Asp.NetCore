﻿using System;
using System.Collections.Generic;

namespace CRUD_API.Models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public int? Age { get; set; }
        public int? Class { get; set; }
        public string? Email { get; set; }
        public string? Pass { get; set; }
    }
}
