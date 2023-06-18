using Microsoft.AspNetCore.Mvc;
using QuizApp.Core.Services;
using QuizApp.Models.DTOs.QuestionSets.Create;

namespace QuizApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionSetsController : ControllerBase
    {
        private readonly IQuestionSetService _questionSetService;

        public QuestionSetsController(IQuestionSetService questionSetService)
        {
            _questionSetService = questionSetService;
        }

        [HttpPost]
        public IActionResult Create(QuestionSetCreateDto request)
        {
            var response = _questionSetService.Create(request);

            return Ok(response);
        }
    }
}
