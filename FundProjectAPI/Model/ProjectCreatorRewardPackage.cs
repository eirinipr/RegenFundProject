namespace FundProjectAPI.Model
{
    public class ProjectCreatorRewardPackage
    {
        public int Id { get; set; }
        public ProjectCreator ProjectCreator { get; set; }  
        public RewardPackage RewardPackage { get; set; } 
    }
}
