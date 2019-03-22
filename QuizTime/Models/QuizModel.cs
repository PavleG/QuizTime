using System.Collections.Generic;
namespace QuizTime.Models{
    public class QuizModel{
        public int QuizModelID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public IEnumerable<QuestionModel> Questions { get; set; }
    }

    public class QuestionModel
    {
        public int QuestionModelID { get; set; }
        public string QuestionFormulation { get; set; }
        public string CorrectAnswer {get; set;}
        public string WrongAnswer { get; set; }
    }
}