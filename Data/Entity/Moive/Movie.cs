using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AllInOne.Data.Entity.Moive.Enums;
using AllInOne.Data.Entity.Security;

namespace AllInOne.Data.Entity.Moive
{
    [Table("Movie", Schema = "Movie")]
    public class Movie : BaseEntity
    {
        public long UserId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(10)]
        public string Year { get; set; }
        [MaxLength(20)]
        public string Rated { get; set; }
        [MaxLength(20)]
        public string Released { get; set; }
        [MaxLength(1000)]
        public string Plot { get; set; }
        [MaxLength(200)]
        public string Awards { get; set; }
        [MaxLength(100)]
        public string Poster { get; set; }
        [MaxLength(50)]
        public string Metascore { get; set; }
        [MaxLength(50)]
        public string ImdbRating { get; set; }
        [MaxLength(50)]
        public string ImdbVotes { get; set; }
        [MaxLength(20)]
        public string ImdbId { get; set; }
        public TypeKind Type { get; set; }
        [MaxLength(20)]
        public string DvdReleaseDate { get; set; }
        [MaxLength(20)]
        public string BoxOffice { get; set; }
        [MaxLength(50)]
        public string Production { get; set; }
        [MaxLength(100)]
        public string Website { get; set; }
        [MaxLength(10)]
        public string TotalSeasons { get; set; }
        [MaxLength(20)]
        public string SeriesId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MovieGenre> MovieGenres { get; set; }
        public virtual ICollection<MovieCast> MovieCasts { get; set; }
        public virtual ICollection<MovieLanguage> MovieLanguages { get; set; }
        public virtual ICollection<MovieCountry> MovieCountries { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}