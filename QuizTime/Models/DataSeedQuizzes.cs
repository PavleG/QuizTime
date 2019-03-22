using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

namespace QuizTime.Models {
    public static class SeedDataQuizzes
    {
        public static void EnsurePopulated(IApplicationBuilder app){
            AppDbContext context = app.ApplicationServices
                .GetRequiredService<AppDbContext>();
            context.Database.Migrate();
            if (!context.ListOfQuizzes.Any()){
                context.ListOfQuizzes.AddRange(
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
                );
                context.SaveChanges();
            }
        }
    }
}