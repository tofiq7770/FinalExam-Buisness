using FinalExam.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
                
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Setting> Settings { get; set; }
    }
}
