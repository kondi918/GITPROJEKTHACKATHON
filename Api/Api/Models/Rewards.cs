namespace Api.Models
{
    public class Rewards
    {
        public int Id { get; set; }
        public string RewardName { get; set; }
        public string Description { get; set; }
        public int Cost { get; set; }
        public int Quantity { get; set; }
        public ICollection<UserRewards> UserRewards { get; set; }

    }
}
