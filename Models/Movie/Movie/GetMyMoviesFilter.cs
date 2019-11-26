using System.Collections.Generic;

namespace AllInOne.Models.Movie.Movie
{
    public class GetMyMoviesFilter
    {
        public string Title { get; set; }
        public double MinRate { get; set; }
        public double MaxRate { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public List<string> Rated { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Star { get; set; }
        public bool? Seen { get; set; }
        public bool ShowAllInfo { get; set; }
    }
}