using Api.Models.DTO;

namespace Api.Models.Requests
{
    public class CreateQuizRequest
    {
        public QuizDTO Quiz { get; set; }
        public List<QuestionDTO> Questions { get; set; }
    }
}
