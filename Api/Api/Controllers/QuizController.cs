using Api.Data;
using Api.Models.Requests;
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
                
                UserService usersService = new UserService(_databaseContext);
                //var result = await usersService.AddUser(request);
               // if (result)
                //{
                   // return Ok(true);
               // }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
                
        }
    }
}
