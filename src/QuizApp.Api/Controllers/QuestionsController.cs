using Microsoft.AspNetCore.Mvc;
using QuizApp.Core.Extensions;
using QuizApp.Core.Repositories;
using QuizApp.Core.Services;
using QuizApp.Models.DTOs.Questions.Create;
using QuizApp.Models.Entities;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;
        private readonly Repository<Question> _repository;
        public QuestionsController(IQuestionService questionService,Repository<Question> repository)
        {
            _questionService = questionService;
            _repository = repository;
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

        [HttpPatch("{id}")]
        public IActionResult ChangeQuestion(Guid id,string text)
        {
            var entity = _repository.GetFirst(x => x.Id == id);

            _repository.Edit(entity, entry =>
            {
                entry.SetValue(x => x.Text, text);
            });

            return NoContent();
        }
    }
}
