using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundProjectAPI.DTOs
{
    public class ProjectCreatorDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }
        public List<RewardPackageDto> RewardpackagesDtos { get; set; }


    }
}
