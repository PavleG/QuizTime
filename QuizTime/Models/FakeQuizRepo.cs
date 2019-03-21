// This is a temporary storage for quizzes

using System.Collections.Generic;
using System.Linq;

namespace QuizTime.Models {
    public class FakeQuizRepo : IQuizRepository {
        public IQueryable<QuizModel> ListOfQuizzes => new List<QuizModel> {
            new QuizModel { Title="Capitals of Europe", 
                            Author="A1", 
                            Category="Geography",
                            Questions = new List<QuestionModel>{
                                new QuestionModel { 
                                    QuestionFormulation = "Capital of Estonia is...",
                                    CorrectAnswer = "Talin",
                                    WrongAnswer = "Riga"
                                    },
                                new QuestionModel { 
                                    QuestionFormulation = "Capital of Italy is...",
                                    CorrectAnswer = "Rome",
                                    WrongAnswer = "Paris"
                                    }
                            }
                        },
            new QuizModel { Title="US presidents", 
                            Author="A2", 
                            Category="History",
                            Questions = new List<QuestionModel>{
                                new QuestionModel { 
                                    QuestionFormulation = "1st US president was...",
                                    CorrectAnswer = "George Washington",
                                    WrongAnswer = "Thomas Jefferson"
                                    },
                                new QuestionModel { 
                                    QuestionFormulation = "Which president was in office during World War I?",
                                    CorrectAnswer = "Woodrow Wilson",
                                    WrongAnswer = "John F. Kennedy"
                                    }
                            }
                        }
        }.AsQueryable<QuizModel>();
    }
}