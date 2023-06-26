using QuizApp.Models.Entities;

namespace QuizApp.Models.DTOs.Questions.SaveAnswer
{
    public class QuestionSaveAnswerDto
    {
        public Guid? Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }

        public Answer ToModel()
        {
            return new Answer
            {
                Id = Guid.NewGuid(),
                Text = this.Text,
                IsCorrect = this.IsCorrect,
                QuestionId = this.QuestionId
            };
        }
    }
}
