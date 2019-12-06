namespace AllInOne.Models.Movie.Movie
{
    public class AddMovieToCollectionInput
    {
        public long CollectionId { get; set; }
        public long MovieId { get; set; }
        public byte Number { get; set; }
    }
}