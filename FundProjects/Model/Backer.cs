﻿using FundProjects.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjects.Model
{
    public class Backer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<BackerProject> BackerProjects { get; set; } 
    }
}