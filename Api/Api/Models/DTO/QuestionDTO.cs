namespace Api.Models.DTO
{
    public class QuestionDTO
    {
        public int Id { get; set; }
        public List<AnswerDTO> Answers { get; set; }
        public string QuestionText { get; set; }
    }
}
