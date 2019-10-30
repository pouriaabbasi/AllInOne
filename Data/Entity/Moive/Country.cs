using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("Country", Schema = "Movie")]
    public class Country : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<MovieCountry> MovieCountries { get; set; }

    }
}