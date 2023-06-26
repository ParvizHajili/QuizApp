using QuizApp.Models.Entities;

namespace QuizApp.Models.DTOs.Questions.Create
{
    public class QuestionCreateResponseDto
    {
        public Guid Id { get; set; }
        public byte Point { get; set; }
        public string Text { get; set; }

        public static QuestionCreateResponseDto Create(Question question)
        {
            return new QuestionCreateResponseDto
            {
                Id = question.Id,
                Text = question.Text,
                Point = question.Point,
            };
        }
    }
}
