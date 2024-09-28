namespace Api.Models
{
    public class Questions
    {
        public int Id { get; set; }
        public int QuizId { get; set; }
        public string QuestionText { get; set; }
        public DateTime CreatedAt { get; set; }
        public Quizes Quiz { get; set; }
        public ICollection<Answers> Answers { get; set; }
        public ICollection<UserAnswers> UserAnswers { get; set; }   
    }
}
