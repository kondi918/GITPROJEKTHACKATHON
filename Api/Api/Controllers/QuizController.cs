using Api.Data;
using Api.Models.DTO;
using Api.Models.Requests;
using Api.Responses;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuizController : ControllerBase
    {
        private readonly DatabaseContext _databaseContext;
        public QuizController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        [HttpPost("PostQuiz", Name = "PostQuiz")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> CreateQuiz(CreateQuizRequest request)
        {
            try
            {
                QuizService quizService = new QuizService(_databaseContext);
                var result = await quizService.AddQuiz(request);
               if(result)
               {
                    return Ok(true);
               }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
                
        }
        [HttpGet("GetAllQuizes", Name = "GetAllQuizes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<QuizDTO>>> GetAllQuizes(string category)
        {
            try
            {
                QuizService quizService = new QuizService(_databaseContext);
                var result = await quizService.GetAllQuizes(category);
                if(result != null && result.Count > 0)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetSingleQuiz", Name = "GetSingleQuiz")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SingleQuizResponse>> GetSingleQuiz(int quizId)
        {
            try
            {
                QuizService quizService = new QuizService(_databaseContext);
                var result = await quizService.GetSingleQuiz(quizId);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("GetQuestion", Name = "GetQuestion")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AnswerDTO>>> GetQuestion(int questionId)
        {
            try
            {
                QuizService quizService = new QuizService(_databaseContext);
                var result = await quizService.GetSingleQuestion(questionId);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("GetAnswers", Name = "GetAnswers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<AnswerDTO>>> GetAnswers(int questionId)
        {
            try
            {
                QuizService quizService = new QuizService(_databaseContext);
                var result = await quizService.GetAnswers(questionId);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
