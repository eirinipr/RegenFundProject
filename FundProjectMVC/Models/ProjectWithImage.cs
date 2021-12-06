using FundProjectAPI.DTOs;
using FundProjectAPI.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Models
{
    public class ProjectWithImage
    {
        public Project Project { get; set; }
        public IFormFile ProjectImage { set; get; }
        public RewardPackage RewardPackage { get; set; }

    }
}
