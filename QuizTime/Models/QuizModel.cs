using System.Collections.Generic;
namespace QuizTime.Models{
    public class QuizModel{
        public IEnumerable<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public string Question { get; set; }
        public string CorrectAnswer{get; set;}
        public string WrongAnswer { get; set; }
    }
}