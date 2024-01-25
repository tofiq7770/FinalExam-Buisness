using FinalExam.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
        {
                
        }
        DbSet<Blog> Blogs { get; set; }
    }
}
