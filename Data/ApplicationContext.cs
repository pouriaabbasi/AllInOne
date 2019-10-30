using AllInOne.Data.Entity.Accounting;
using AllInOne.Data.Entity.Bot;
using AllInOne.Data.Entity.LeitnerBox;
using AllInOne.Data.Entity.Moive;
using AllInOne.Data.Entity.Security;
using AllInOne.Data.Entity.Todo;
using Microsoft.EntityFrameworkCore;

namespace AllInOne.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        #region Accounting
        public DbSet<Plan> Plans { get; set; }
        public DbSet<PlanDetail> PlanDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        #endregion

        #region Bot
        public DbSet<TelegramUser> TelegramUsers { get; set; }
        #endregion

        #region LeitnerBox
        public DbSet<Box> Boex { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionHistory> QuestionHistories { get; set; }
        #endregion

        #region Movie
        public DbSet<Cast> Casts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCountry> MovieCountries { get; set; }        
        public DbSet<MovieGenre> MovieGenres { get; set; }        
        public DbSet<MovieLanguage> MovieLanguages { get; set; }        
        public DbSet<Rating> Ratings { get; set; }        
        #endregion

        #region Security
        public DbSet<User> Users { get; set; }
        #endregion

        #region Todo
        public DbSet<Group> Groups { get; set; }
        public DbSet<List> Lists { get; set; }
        public DbSet<Item> Items { get; set; }
        #endregion
    }
}