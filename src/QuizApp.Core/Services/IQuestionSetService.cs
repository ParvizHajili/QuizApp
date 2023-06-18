using QuizApp.Models.DTOs.QuestionSets.Create;

namespace QuizApp.Core.Services
{
    public interface IQuestionSetService
    {
        public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request);
    }
}
