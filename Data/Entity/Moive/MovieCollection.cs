using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("MovieCollection", Schema = "Movie")]
    public class MovieCollection : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<MovieCollectionDetail> MovieCollectionDetails { get; set; }
    }
}