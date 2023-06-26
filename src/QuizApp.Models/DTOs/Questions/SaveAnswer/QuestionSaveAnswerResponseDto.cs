using QuizApp.Models.Entities;

namespace QuizApp.Models.DTOs.Questions.SaveAnswer
{
    public class QuestionSaveAnswerResponseDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public static QuestionSaveAnswerResponseDto Create (Answer answer)
        {
            return new QuestionSaveAnswerResponseDto
            {
                Id = answer.Id,
                Text = answer.Text,
                IsCorrect = answer.IsCorrect,
            };
        }
    }
}
