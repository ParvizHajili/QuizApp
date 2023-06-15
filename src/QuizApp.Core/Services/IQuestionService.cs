using QuizApp.Models.DTOs.Questions.Create;
using QuizApp.Models.DTOs.Questions.GetById;

namespace QuizApp.Core.Services
{
    public interface IQuestionService
    {
        public QuestionCreateResponseDto Create(QuestionCreateDto request);
        public QuestionGetByIdResponseDto GetById(Guid id);
    }
}
