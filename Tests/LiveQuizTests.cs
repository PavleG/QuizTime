using QuizTime.Models;
using Xunit;
namespace QuizTime.Tests{
    public class LiveQuizTests{
        [Fact]
        public void UniqueUserTest(){
            //Arrange - creating some fictional usernames
            string User1 = "UserName1";
            string User2 = "UserName2";
            string User3 = "UserName1";

            //Arrange - creating an active quiz
            LiveQuiz demoQuiz = new LiveQuiz();

            //Act - adding users to the quiz
            var b1 = demoQuiz.AddPlayerToQuiz(User1);
            var b2 = demoQuiz.AddPlayerToQuiz(User2);
            var b3 = demoQuiz.AddPlayerToQuiz(User3);
            //Assert
            Assert.True(b1);
            Assert.True(b2);
            Assert.False(b3);
        }
    }
}