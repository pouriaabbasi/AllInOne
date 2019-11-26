using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieCollectionDetail", Schema = "Movie")]
    public class MovieCollectionDetail : BaseEntity
    {
        public long MovieCollectionId { get; set; }
        public long MovieId { get; set; }
        public byte Number { get; set; }

        public virtual MovieCollection MovieCollection { get; set; }
        public virtual Movie Movie { get; set; }
    }
}