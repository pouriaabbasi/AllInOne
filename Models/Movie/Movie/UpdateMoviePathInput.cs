namespace AllInOne.Models.Movie.Movie
{
    public class UpdateMoviePathInput
    {
        public long MovieId { get; set; }
        public string oldPath { get; set; }
        public string NewPath { get; set; }
    }
}