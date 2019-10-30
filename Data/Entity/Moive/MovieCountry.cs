using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieCountry", Schema = "Movie")]
    public class MovieCountry : BaseEntity
    {
        public long MovieId { get; set; }
        public long CountryId { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Country Country { get; set; }
    }
}