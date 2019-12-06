namespace AllInOne.Models.Movie.Movie
{
    public class RemoveMovieFromCollectionInput
    {
        public long CollectionId { get; set; }
        public long MovieId { get; set; }
    }
}