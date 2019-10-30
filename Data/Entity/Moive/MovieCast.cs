using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Moive.Enums;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieCast", Schema = "Movie")]
    public class MovieCast : BaseEntity
    {
        public long MovieId { get; set; }
        public long CastId { get; set; }
        public CastTypeKind CastType { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual Cast Cast { get; set; }
    }
}