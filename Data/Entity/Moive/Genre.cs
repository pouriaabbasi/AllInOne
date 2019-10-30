using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("Genre", Schema = "Movie")]
    public class Genre : BaseEntity
    {
        [MaxLength(50)]
        public string Title { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
    }
}