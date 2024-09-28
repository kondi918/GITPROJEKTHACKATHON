namespace Api.Models.DTO
{
    public class QuestionDTO
    {
        List<AnswerDTO> Answers { get; set; }
        public string QuestionText { get; set; }
    }
}
