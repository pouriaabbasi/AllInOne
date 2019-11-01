using System;
using System.Collections.Generic;
using System.Linq;
using AllInOne.Data.Entity.Moive.Enums;

namespace AllInOne.Models.Movie.Movie
{
    public class ImdbMovieModel
    {
        public ImdbMovieModel(string title, string year, string rated, string released, string runtime, string genre, string director, string writer, string actors, string plot, string language, string country, string awards, string poster, string metascore, string imdbRating, string imdbVotes, string imdbID, string type, string dVD, string boxOffice, string production, string website, string totalSeasons, string seriesId)
        {
            this.Title = title;
            this.Year = year;
            this.Rated = rated;
            this.Released = released;
            this.Runtime = runtime;
            this.Genre = genre;
            this.Director = director;
            this.Writer = writer;
            this.Actors = actors;
            this.Plot = plot;
            this.Language = language;
            this.Country = country;
            this.Awards = awards;
            this.Poster = poster;
            this.Metascore = metascore;
            this.imdbRating = imdbRating;
            this.imdbVotes = imdbVotes;
            this.imdbID = imdbID;
            this.Type = type;
            this.DVD = dVD;
            this.BoxOffice = boxOffice;
            this.Production = production;
            this.Website = website;
            this.TotalSeasons = totalSeasons;
            this.SeriesId = seriesId;

        }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<ImdbRatingModel> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string TotalSeasons { get; set; }
        public string SeriesId { get; set; }

        public Dictionary<string, CastTypeKind> GetCasts()
        {
            var result = new Dictionary<string, CastTypeKind>();

            foreach (var director in Director.Split(',').Select(x => x.Trim()))
                result.Add(director, CastTypeKind.Director);

            foreach (var writer in Writer.Split(',').Select(x => x.Trim()))
            {
                var finalWriter = writer;
                var startRemoveIndex = writer.IndexOf('(');
                if (startRemoveIndex != -1)
                    finalWriter = writer.Remove(startRemoveIndex);
                result.Add(finalWriter, CastTypeKind.Writer);
            }

            foreach (var actor in Actors.Split(',').Select(x => x.Trim()))
                result.Add(actor, CastTypeKind.Actor);

            return result;
        }

        public List<string> GetCountries()
        {
            return Country
                .Split(',')
                .Select(x => x.Trim())
                .ToList();
        }

        public List<string> GetGenres()
        {
            return Genre
                .Split(',')
                .Select(x => x.Trim())
                .ToList();
        }

        public List<string> GetLanguages()
        {
            return Language
                .Split(',')
                .Select(x => x.Trim())
                .ToList();
        }

        public Dictionary<string, string> GetRatings()
        {
            return Ratings
                .ToDictionary(x => x.Source, x => x.Value);
        }
    }
}