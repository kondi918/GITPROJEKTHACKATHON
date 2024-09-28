namespace Api.Models
{
    public class UserAnswers
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuizId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public bool IsCorrect { get; set; }
        public DateTime AnsweredAt { get; set; }
        public Users Users { get; set; }
        public Quizes Quizes { get; set; } 
        public Questions Questions { get; set; }
        public Answers Answers { get; set; }
    }
}
