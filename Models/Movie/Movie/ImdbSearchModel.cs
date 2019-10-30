using System.Collections.Generic;

namespace AllInOne.Models.Movie.Movie
{
    public class ImdbSearchModel
    {
        public List<SearchModel> Search { get; set; }
        public string totalResults { get; set; }
    }
}