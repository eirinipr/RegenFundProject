using FundProjectAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectMVC.Models
{
    public class MultipleModelsGet
    {
        public ProjectDto ProjectDto { get; set; }
        public RewardPackageDto RewardPackageDto { get; set; }
    }
}
