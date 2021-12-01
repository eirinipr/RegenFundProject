using System.Collections.Generic;

namespace FundProjectAPI.Model
{
    public class RewardPackage
    {
        public int Id { get; set; }
        public decimal FundAmount { get; set; }
        public string Reward { get; set; }
        List<ProjectCreator> ProjectCreators { get; set; } = new();

    }
}
