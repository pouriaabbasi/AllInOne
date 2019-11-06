using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Moive;
using AllInOne.Data.Entity.Moive.Enums;
using AllInOne.Models.Movie.Movie;
using AllInOne.Services.Contract.Movie;
using Newtonsoft.Json;

namespace AllInOne.Services.Implementation.Movie
{
    public class MovieLib : IMovieLib
    {
        const string _baseUrl = "http://www.omdbapi.com/?apiKey=c651206f&";
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Data.Entity.Moive.Movie> movieRepo;
        private readonly IRepository<Cast> castRepo;
        private readonly IRepository<Country> countryRepo;
        private readonly IRepository<Genre> genreRepo;
        private readonly IRepository<Language> languageRepo;

        public MovieLib(
            IUnitOfWork unitOfWork,
            IRepository<Data.Entity.Moive.Movie> movieRepo,
            IRepository<Cast> castRepo,
            IRepository<Country> countryRepo,
            IRepository<Genre> genreRepo,
            IRepository<Language> languageRepo
            )
        {
            this.unitOfWork = unitOfWork;
            this.movieRepo = movieRepo;
            this.castRepo = castRepo;
            this.countryRepo = countryRepo;
            this.genreRepo = genreRepo;
            this.languageRepo = languageRepo;
        }

        public async Task<ImdbSearchModel> ImdbSearchAsync(InputImdbSearchModel model)
        {
            var url = model.CreateRequestUrl(_baseUrl);
            return await GetAsync<ImdbSearchModel>(url);
        }

        public async Task<ImdbMovieModel> ImdbGetInfoByIdAsync(string imdbId)
        {
            var url = $"{_baseUrl}i={imdbId}";
            return await GetAsync<ImdbMovieModel>(url);
        }

        public async Task<bool> AddMovieFromImdbAsync(string imdbId, long currentUserId)
        {
            var movieEntity = await movieRepo.FirstAsync(x => x.ImdbId == imdbId);
            if (movieEntity != null) throw new Exception("Duplicate Movie");

            var url = $"{_baseUrl}i={imdbId}";
            var result = await GetAsync<ImdbMovieModel>(url);
            var entity = new Data.Entity.Moive.Movie
            {
                Awards = result.Awards,
                BoxOffice = result.BoxOffice,
                DvdReleaseDate = result.DVD,
                ImdbId = result.imdbID,
                ImdbRating = result.imdbRating,
                ImdbVotes = result.imdbRating,
                Metascore = result.Metascore,
                MovieCasts = await GetCasts(result.GetCasts()),
                MovieCountries = await GetCountries(result.GetCountries()),
                MovieGenres = await GetGenres(result.GetGenres()),
                MovieLanguages = await GetLanguages(result.GetLanguages()),
                Plot = result.Plot,
                Poster = result.Poster,
                Production = result.Production,
                Rated = result.Rated,
                Ratings = CreateRating(result.GetRatings()),
                Released = result.Released,
                SeriesId = result.SeriesId,
                Title = result.Title,
                TotalSeasons = result.TotalSeasons,
                Type = (TypeKind)Enum.Parse(typeof(TypeKind), result.Type),
                UserId = currentUserId,
                Website = result.Website,
                Year = result.Year
            };

            await movieRepo.AddAsync(entity);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<List<MovieModel>> GetMyMoviesAsync(long currentUserId)
        {
            var result = await movieRepo.GetQuery()
                .Where(x => x.UserId == currentUserId)
                .ToAsyncEnumerable()
                .Select(x => new MovieModel
                {
                    Title = x.Title,
                    Type = x.Type.ToString(),
                    Year = x.Year,
                    Director = string.Join(",", x.MovieCasts.Where(r => r.CastType == CastTypeKind.Director).Select(r => r.Cast.FullName))
                })
                .ToList();

            return result;
        }

        private List<Rating> CreateRating(Dictionary<string, string> rates)
        {
            var result = new List<Rating>();

            foreach (var rate in rates)
                result.Add(new Rating
                {
                    SourceName = rate.Key,
                    Value = rate.Value
                });

            return result;
        }

        private async Task<List<MovieLanguage>> GetLanguages(List<string> languages)
        {
            var result = new List<MovieLanguage>();

            foreach (var language in languages)
            {
                var languageEntity = await languageRepo.FirstAsync(x => x.Name == language);
                if (languageEntity == null)
                    languageEntity = new Language
                    {
                        Name = language
                    };
                result.Add(new MovieLanguage
                {
                    Language = languageEntity
                });
            }

            return result;
        }

        private async Task<List<MovieGenre>> GetGenres(List<string> genres)
        {
            var result = new List<MovieGenre>();
            foreach (var genre in genres)
            {
                var genreEntity = await genreRepo.FirstAsync(x => x.Title == genre);
                if (genreEntity == null)
                {
                    genreEntity = new Genre
                    {
                        Title = genre
                    };
                }
                result.Add(new MovieGenre
                {
                    Genre = genreEntity
                });
            }

            return result;
        }

        private async Task<List<MovieCountry>> GetCountries(List<string> countries)
        {
            var result = new List<MovieCountry>();
            foreach (var country in countries)
            {
                var countryEntity = await countryRepo.FirstAsync(x => x.Name == country);
                if (countryEntity == null)
                    countryEntity = new Country
                    {
                        Name = country
                    };
                result.Add(new MovieCountry
                {
                    Country = countryEntity
                });
            }
            return result;
        }

        private async Task<List<MovieCast>> GetCasts(List<AddCastModel> casts)
        {
            var result = new List<MovieCast>();

            foreach (var cast in casts)
            {
                var castEntity = await castRepo.FirstAsync(x => x.FullName.ToLower() == cast.FullName.ToLower());
                if (castEntity == null)
                    castEntity = new Cast
                    {
                        FullName = cast.FullName
                    };
                result.Add(new MovieCast
                {
                    Cast = castEntity,
                    CastType = cast.CastType
                });
            }

            return result;
        }

        private async Task<T> GetAsync<T>(string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse)await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var result = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}