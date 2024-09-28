using Api.Models.DTO;

namespace Api.Models.Requests
{
    public class CreateQuizRequest
    {
        QuizDTO Quiz { get; set; }
        List<QuestionDTO> Questions { get; set; }
    }
}
