using QuizApp.Core.Extensions;
using QuizApp.Core.Repositories.Special;
using QuizApp.Core.Services;
using QuizApp.Models.DTOs.Questions.Create;
using QuizApp.Models.DTOs.Questions.GetById;
using QuizApp.Models.DTOs.Questions.Save;
using QuizApp.Models.DTOs.Questions.SaveAnswer;

namespace QuizApp.Application.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IAnswerRepository _answerRepository;
        public QuestionService(IQuestionRepository questionRepository, IAnswerRepository answerRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public QuestionCreateResponseDto Create(QuestionCreateDto request)
        {
            var entity = request.ToEntity();

            _questionRepository.Add(entity);
            _questionRepository.Save();

            var response = QuestionCreateResponseDto.Create(entity);

            return response;
        }

        public QuestionGetByIdResponseDto GetById(Guid id)
        {
            var entity = _questionRepository.GetFirst(x => x.Id == id);

            return QuestionGetByIdResponseDto.Create(entity);
        }

        public void Remove(Guid id)
        {
            var entity = _questionRepository.GetFirst(x => x.Id == id);

            _questionRepository.Remove(entity);
            _questionRepository.Save();
        }

        public void RemoveAnswer(Guid id)
        {
            var entity = _answerRepository.GetFirst(x => x.Id == id);

            _answerRepository.Remove(entity);
            _answerRepository.Save();
        }

        public void Save(QuestionSaveDto request)
        {
            var question = _questionRepository.GetFirst(x => x.Id == request.Id);

            _questionRepository.Edit(question, entry =>
            {
                entry.SetValue(x => x.Text, request.Text)
                .SetValue(x => x.Point, request.Point)
                .SetValue(x => x.QuestionSetId, request.QuestionSetId);
            });

            var correctAnswer = _answerRepository.GetFirst(x => x.Id == request.CorrectAnswerId);

            _answerRepository.Edit(correctAnswer, entry => entry.SetValue(x => x.IsCorrect, true));

            var otherAnswers = _answerRepository.GetAll(x => x.QuestionId == request.QuestionSetId && x.Id != request.CorrectAnswerId).ToArray();

            foreach (var item in otherAnswers)
            {
                _answerRepository.Edit(item, entry => entry.SetValue(x => x.IsCorrect, false));
            }
        }

        public QuestionSaveAnswerResponseDto SaveAnswer(QuestionSaveAnswerDto request)
        {
            //todo
            var answer = _answerRepository.GetFirst(x => x.Id == request.Id);

            if (answer == null)
            {
                answer = request.ToModel();
                _answerRepository.Add(answer);
            }
            else
            {
                _answerRepository.Edit(answer, entry =>
                {
                    entry.SetValue(x => x.Text, request.Text);
                    entry.SetValue(x => x.IsCorrect, request.IsCorrect);
                    entry.SetValue(x => x.QuestionId, request.QuestionId);
                });
            }
            if (request.IsCorrect)
            {
                var otherAnswers = _answerRepository.GetAll(x => x.QuestionId == answer.QuestionId && x.Id != request.Id).ToList();

                foreach (var item in otherAnswers)
                {
                    _answerRepository.Edit(item, entry => entry.SetValue(x => x.IsCorrect, false));
                }
            }

            _answerRepository.Save();

            return QuestionSaveAnswerResponseDto.Create(answer);
        }
    }
}
