using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("Cast", Schema = "Movie")]
    public class Cast : BaseEntity
    {
        [MaxLength(200)]
        public string FullName { get; set; }

        public virtual ICollection<MovieCast> MovieCasts { get; set; }

    }
}