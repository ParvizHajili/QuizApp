using QuizApp.Models.Entities;

namespace QuizApp.Models.DTOs.Questions.Create
{
    public class QuestionCreateDto
    {
        public string Text { get; set; }
        public byte Point { get; set; }
        public Guid QuestionSetId { get; set; }

        public Question ToEntity()
        {
            return new Question
            {
                Id = Guid.NewGuid(),
                Text = this.Text,
                Point = this.Point,
                QuestionSetId = this.QuestionSetId
            };
        }
    }
}
