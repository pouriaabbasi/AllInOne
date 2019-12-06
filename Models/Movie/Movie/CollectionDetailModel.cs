namespace AllInOne.Models.Movie.Movie
{
    public class CollectionDetailModel
    {
        public long CollectionDetailId { get; set; }
        public int Number { get; set; }
        public string MovieName { get; set; }
        public MovieModel Movie { get; set; }
    }
}