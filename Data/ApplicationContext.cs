using AllInOne.Model.Todo;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Group> Groups { get; set; }
        public DbSet<List> Lists { get; set; }
    }
}