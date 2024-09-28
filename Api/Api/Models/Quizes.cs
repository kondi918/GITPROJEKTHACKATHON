using Microsoft.Extensions.Hosting;

namespace Api.Models
{
    public class Quizes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public int PointRewards { get; set; }
        public ICollection<Questions> Questions { get; set; }
        public ICollection<UserAnswers> UserAnswers { get; set; }

    }
}
