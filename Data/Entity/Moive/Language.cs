using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllInOne.Data.Entity.Moive
{
    [Table("Language", Schema = "Movie")]
    public class Language : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }
    }
}