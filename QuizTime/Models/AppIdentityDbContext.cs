using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace QuizTime.Models{
    public class AppIdentityDbContext : IdentityDbContext<User>{
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options){}
    }
}