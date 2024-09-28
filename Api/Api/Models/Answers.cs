namespace Api.Models
{
    public class Answers
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }
        public Questions Questions { get; set; }
        public ICollection<UserAnswers> UserAnswers { get; set; }
    }
}
