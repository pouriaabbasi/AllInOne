namespace AllInOne.Models.Movie.Movie
{
    public class MovieModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImdbRating { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public bool Seen { get; set; }
        public string LocalPath { get; set; }
        public string Poster { get; set; }
    }
}