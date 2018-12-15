using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;

namespace QuizTime.Models{
    public class AppDbContext : DbContext{
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options){}
    }
}