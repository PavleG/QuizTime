using System.Collections.Generic;
using System.Linq;

namespace QuizTime.Models {
    public class EFQuizRepository : IQuizRepository
    {
        private AppDbContext _context;
        public EFQuizRepository(AppDbContext ctx)
        {
            _context = ctx;
        }
        public IQueryable<QuizModel> ListOfQuizzes => _context.ListOfQuizzes;
    }
}