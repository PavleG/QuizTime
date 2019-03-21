using System.Linq;

namespace QuizTime.Models {
    public interface IQuizRepository
    {
        IQueryable<QuizModel> ListOfQuizzes { get; }        
    }
}