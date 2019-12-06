using System.Collections.Generic;

namespace AllInOne.Models.Movie.Movie
{
    public class CollectionMoviesModel
    {
        public long CollectionId { get; set; }
        public string Name { get; set; }
        public List<CollectionDetailModel> CollectionDetails { get; set; }
    }
}