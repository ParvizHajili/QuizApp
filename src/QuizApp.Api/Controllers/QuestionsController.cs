using Microsoft.AspNetCore.Mvc;
using QuizApp.Core.Services;
using QuizApp.Models.DTOs.Questions.Create;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult Create(QuestionCreateDto request)
        {
            var response =_questionService.Create(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _questionService.GetById(id);

            return Ok(response);
        }
    }
}
