using QuizApp.Models.DTOs.Questions.Create;
using QuizApp.Models.DTOs.Questions.GetById;
using QuizApp.Models.DTOs.Questions.Save;
using QuizApp.Models.DTOs.Questions.SaveAnswer;

namespace QuizApp.Core.Services
{
    public interface IQuestionService
    {
        public QuestionCreateResponseDto Create(QuestionCreateDto request);
        public void Save(QuestionSaveDto request);
        public QuestionGetByIdResponseDto GetById(Guid id);
        public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request);
        public void RemoveAnswer(Guid id);
        public void Remove(Guid id);
    }
}
