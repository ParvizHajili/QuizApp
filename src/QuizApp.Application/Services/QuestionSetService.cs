using QuizApp.Core.Repositories.Special;
using QuizApp.Core.Services;
using QuizApp.Models.DTOs.QuestionSets.Create;

namespace QuizApp.Application.Services
{
    public class QuestionSetService : IQuestionSetService
    {
        private readonly IQuestionSetRepository _questionSetRepository;

        public QuestionSetService(IQuestionSetRepository questionSetRepository)
        {
            _questionSetRepository = questionSetRepository;
        }

        public QuestionSetCreateResponseDto Create(QuestionSetCreateDto request)
        {
            var entity = request.ToEntity();

            entity = _questionSetRepository.Add(entity);
            _questionSetRepository.Save();

            var response = QuestionSetCreateResponseDto.Create(entity);

            return response;
        }
    }
}
