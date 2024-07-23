using ApiDevQuiz.Models;
using ApiDevQuiz.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiDevQuiz.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QuestionController : ControllerBase
    {
        private readonly QuestionService _questionService;

        public QuestionController(QuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public ActionResult<QuestionModel> Get()
        {
            var question = _questionService.GetRandomQuestion();

            if (question == null)
            {
                return NotFound("No questions available.");
            }

            return Ok(question);
        }
    }
}
