using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using QuizTime.Models;
using Xunit;

namespace QuizTime.Tests
{
    public class QuizModelTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {GetAllQuizzes()};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private IQueryable<QuizModel> GetAllQuizzes()=> new List<QuizModel>{
            new QuizModel{Title = "Quiz1", Author = "Author1", Category = "Category1"},
            new QuizModel{Title = "Quiz2", Author = "Author2", Category = "Category2"},
            new QuizModel{Title = "Quiz3", Author = "Author3", Category = "Category3"},
            new QuizModel{Title = "Quiz4", Author = "Author4", Category = "Category4"},
            new QuizModel{Title = "Quiz5", Author = "Author5", Category = "Category5"}
        }.AsQueryable();
    }
}
