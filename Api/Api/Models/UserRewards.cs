namespace Api.Models
{
    public class UserRewards
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RewardId { get; set; }
        public DateTime RedeemedAt { get; set; }
        public Rewards Rewards { get; set; }
        public Users Users { get; set; }
    }
}
