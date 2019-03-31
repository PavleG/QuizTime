using Xunit;
using Moq;
using System.Linq;
using System.Collections.Generic;
using QuizTime.Models;
using QuizTime.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace QuizTime.Tests{
    public class QuizControllerTests {
        [Theory]
        [ClassData(typeof(QuizModelTestData))]
        public void IndexActionReturnsCompleteList(IQueryable<QuizModel> Quizzes){
            //Arrange
            var mockRepo = new Mock<IQuizRepository>();
            mockRepo.SetupGet(m => m.ListOfQuizzes).Returns(Quizzes);
            var controller = new QuizController(mockRepo.Object);

            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IQueryable<QuizModel>;
            
            //Assert
            Assert.Equal(controller.Repository.ListOfQuizzes, model,
                Comparer.Get<QuizModel>((p1, p2) => p1.Title == p2.Title));
        }

    }
}