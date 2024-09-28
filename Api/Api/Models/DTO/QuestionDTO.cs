namespace Api.Models.DTO
{
    public class QuestionDTO
    {
        public List<AnswerDTO> Answers { get; set; }
        public string QuestionText { get; set; }
    }
}
