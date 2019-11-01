using System;
using AllInOne.Models.Movie.Enums;

namespace AllInOne.Models.Movie.Movie
{
    public class InputImdbSearchModel
    {
        //s
        public string Name { get; set; }
        //type
        public ImdbSearchTypeKind SearchType { get; set; }
        //y
        public int Year { get; set; }
        //page
        public int Page { get; set; }

        internal string CreateRequestUrl(string baseUrl)
        {
            baseUrl += $"s={Name}";
            if (SearchType != 0)
                baseUrl += $"&type={SearchType.ToString()}";
            if (Year != 0)
                baseUrl += $"&y={Year}";
            if (Page != 0)
                baseUrl += $"&page={Page}";
            return baseUrl;
        }
    }
}