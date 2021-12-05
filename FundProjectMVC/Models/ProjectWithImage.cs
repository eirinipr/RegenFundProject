using FundProjectAPI.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Models
{
    public class ProjectWithImage
    {
        public ProjectDto ProjectDto { get; set; }
        public IFormFile ProjectImage { set; get; }
        public RewardPackageDto RewardPackageDto { get; set; }

    }
}
