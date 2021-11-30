﻿using FundProjects.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjects.DTOs
{
    public class ProjectDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectCategory Category { get; set; }
        public int ProjectCreatorId { get; set; }
        public decimal Goal { get; set; }
        public decimal GoalGained { get; set; }
    }
}
