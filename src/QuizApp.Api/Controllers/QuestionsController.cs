using Microsoft.AspNetCore.Mvc;
using QuizApp.Core.Services;
using QuizApp.Models.DTOs.Questions.Create;
using QuizApp.Models.DTOs.Questions.Save;
using QuizApp.Models.DTOs.Questions.SaveAnswer;

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

        [HttpPost]
        public IActionResult Create(QuestionCreateDto request)
        {
            var response = _questionService.Create(request);

            return Ok(response);
        }


        [HttpPost("{save}")]
        public IActionResult Save(QuestionSaveDto request)
        {
            _questionService.Save(request);

            return NoContent();
        }


        [HttpPost("{save-answer}")]
        public IActionResult SaveAnswer(QuestionSaveAnswerDto request)
        {
            var response = _questionService.SaveAnswer(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var response = _questionService.GetById(id);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            _questionService.Remove(id);

            return NoContent();
        }

        [HttpDelete("remove-answer/{id}")]
        public IActionResult RemoveAnswer(Guid id)
        {
            _questionService.RemoveAnswer(id);

            return NoContent();
        }
    }
}
