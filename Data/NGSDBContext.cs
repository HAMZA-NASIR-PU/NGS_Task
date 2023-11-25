using Microsoft.EntityFrameworkCore;
using NGS_Task.Models.Domain;

namespace NGS_Task.Data
{
    public class NGSDBContext : DbContext
    {
        public NGSDBContext(DbContextOptions<NGSDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
