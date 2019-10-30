using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieGenre", Schema = "Movie")]
    public class MovieGenre : BaseEntity
    {
        public long MovieId { get; set; }
        public long GenreId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Genre Genre { get; set; }
    }
}