using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieLanguage", Schema = "Movie")]
    public class MovieLanguage : BaseEntity
    {
        public long MovieId { get; set; }
        public long LanguageId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Language Language { get; set; }
    }
}