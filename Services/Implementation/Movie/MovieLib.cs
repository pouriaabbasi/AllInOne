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
        private readonly IRepository<MovieCollection> movieCollectionRepo;
        private readonly IRepository<MovieCollectionDetail> movieCollectionDetailRepo;

        public MovieLib(
            IUnitOfWork unitOfWork,
            IRepository<Data.Entity.Moive.Movie> movieRepo,
            IRepository<Cast> castRepo,
            IRepository<Country> countryRepo,
            IRepository<Genre> genreRepo,
            IRepository<Language> languageRepo,
            IRepository<MovieCollection> movieCollectionRepo,
            IRepository<MovieCollectionDetail> movieCollectionDetailRepo
            )
        {
            this.unitOfWork = unitOfWork;
            this.movieRepo = movieRepo;
            this.castRepo = castRepo;
            this.countryRepo = countryRepo;
            this.genreRepo = genreRepo;
            this.languageRepo = languageRepo;
            this.movieCollectionRepo = movieCollectionRepo;
            this.movieCollectionDetailRepo = movieCollectionDetailRepo;
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

        public async Task<string> AddMovieFromImdbAsync(AddMovieFromImdbInput model, long currentUserId)
        {
            var movieEntity = await movieRepo.FirstAsync(x => x.ImdbId == model.ImdbId);
            if (movieEntity != null) throw new Exception("Duplicate Movie");

            var url = $"{_baseUrl}i={model.ImdbId}";
            var result = await GetAsync<ImdbMovieModel>(url);
            var entity = new Data.Entity.Moive.Movie
            {
                Awards = result.Awards,
                BoxOffice = result.BoxOffice,
                DvdReleaseDate = result.DVD,
                ImdbId = result.imdbID,
                ImdbRating = result.imdbRating,
                ImdbVotes = result.imdbVotes,
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
                Runtime = result.Runtime,
                SeriesId = result.SeriesId,
                Title = result.Title,
                TotalSeasons = result.TotalSeasons,
                Type = (TypeKind)Enum.Parse(typeof(TypeKind), result.Type),
                UserId = currentUserId,
                Website = result.Website,
                Year = result.Year,
                LocalPath = model.LocalPath
            };
            var posterCount = entity.Poster.Count();
            var plotCount = entity.Plot.Count();

            await movieRepo.AddAsync(entity);
            await unitOfWork.CommitAsync();

            return await BeautifyLocalPathAsync(entity.Id, currentUserId);
        }

        public async Task<List<MovieModel>> GetMyMoviesAsync(GetMyMoviesFilter filter, long currentUserId)
        {
            var result =
                from m in movieRepo.GetQuery()
                join mcd in movieCollectionDetailRepo.GetQuery() on m.Id equals mcd.MovieId into mmcd
                from mcd in mmcd.DefaultIfEmpty()
                join mc in movieCollectionRepo.GetQuery() on mcd.MovieCollectionId equals mc.Id into mcdmc
                from mc in mcdmc.DefaultIfEmpty()
                where
                    m.UserId == currentUserId
                    && (m.Title.Contains(filter.Title) || (mc != null && mc.Name.Contains(filter.Title)))
                    && (filter.MinRate == 0 || Convert.ToDouble(m.ImdbRating) >= filter.MinRate)
                    && (filter.MaxRate == 0 || Convert.ToDouble(m.ImdbRating) <= filter.MaxRate)
                    && (filter.MinYear == 0 || Convert.ToInt32(m.Year) >= filter.MinYear)
                    && (filter.MaxYear == 0 || Convert.ToInt32(m.Year) <= filter.MaxYear)
                    && (filter.Rated == null || filter.Rated.Contains(m.Rated))
                    && (string.IsNullOrWhiteSpace(filter.Genre) || m.MovieGenres.Any(r => r.Genre.Title.Contains(filter.Genre)))
                    && (string.IsNullOrWhiteSpace(filter.Director) || m.MovieCasts.Any(r => r.CastType == CastTypeKind.Director && r.Cast.FullName.Contains(filter.Director)))
                    && (string.IsNullOrWhiteSpace(filter.Writer) || m.MovieCasts.Any(r => r.CastType == CastTypeKind.Writer && r.Cast.FullName.Contains(filter.Writer)))
                    && (string.IsNullOrWhiteSpace(filter.Star) || m.MovieCasts.Any(r => r.CastType == CastTypeKind.Actor && r.Cast.FullName.Contains(filter.Star)))
                    && (filter.Seen == null || m.Seen == filter.Seen)
                orderby mc.Name, mcd.Number, m.Title
                select new MovieModel
                {
                    Id = m.Id,
                    Title = (mc == null ? "" : "(" + mc.Name + " - " + mcd.Number.ToString() + ") ") + m.Title,
                    ImdbRating = m.ImdbRating,
                    Year = m.Year,
                    Rated = m.Rated,
                    Genre = (filter.Genre == string.Empty && !filter.ShowAllInfo) ? string.Empty : string.Join(',', m.MovieGenres.Select(r => r.Genre.Title)),
                    Director = (filter.Director == string.Empty && !filter.ShowAllInfo) ? string.Empty : string.Join(',', m.MovieCasts.Where(r => r.CastType == CastTypeKind.Director).Select(r => r.Cast.FullName)),
                    Writer = (filter.Writer == string.Empty && !filter.ShowAllInfo) ? string.Empty : string.Join(',', m.MovieCasts.Where(r => r.CastType == CastTypeKind.Writer).Select(r => r.Cast.FullName)),
                    Actors = (filter.Star == string.Empty && !filter.ShowAllInfo) ? string.Empty : string.Join(',', m.MovieCasts.Where(r => r.CastType == CastTypeKind.Actor).Select(r => r.Cast.FullName)),
                    LocalPath = m.LocalPath,
                    Poster = m.Poster,
                    Seen = m.Seen
                };

            return await result.ToAsyncEnumerable().ToList();
        }

        public async Task<ImdbMovieModel> GetMovieAsync(long movieId, long currentUserId)
        {
            var entity = await movieRepo.FirstAsync(x => x.Id == movieId && x.UserId == currentUserId);
            if (entity == null) throw new Exception("The movie is not exist");

            return new ImdbMovieModel
            {
                Actors = string.Join(',', entity.MovieCasts.Where(r => r.CastType == CastTypeKind.Actor).Select(r => r.Cast.FullName)),
                Director = string.Join(',', entity.MovieCasts.Where(r => r.CastType == CastTypeKind.Director).Select(r => r.Cast.FullName)),
                Genre = string.Join(',', entity.MovieGenres.Select(r => r.Genre.Title)),
                imdbRating = entity.ImdbRating,
                Poster = entity.Poster,
                Rated = entity.Rated,
                Title = entity.Title,
                Writer = entity.Title,
                Year = entity.Year,
                imdbID = entity.ImdbId,
                Plot = entity.Plot,
                Awards = entity.Awards,
                BoxOffice = entity.BoxOffice,
                Country = string.Join(',', entity.MovieCountries.Select(r => r.Country.Name)),
                DVD = entity.DvdReleaseDate,
                imdbVotes = entity.ImdbVotes,
                Language = string.Join(',', entity.MovieLanguages.Select(r => r.Language.Name)),
                Metascore = entity.Metascore,
                Production = entity.Production,
                Released = entity.Released,
                Runtime = entity.Runtime,
                SeriesId = entity.SeriesId,
                Type = Convert.ToString(entity.Type),
                Website = entity.Website
            };
        }

        public async Task<List<string>> GetAllLocalPathsAsync(long currentUserId)
        {
            var result = await movieRepo.GetQuery()
                .Where(x => x.UserId == currentUserId)
                .Select(x => x.LocalPath)
                .ToAsyncEnumerable()
                .ToList();

            return result;
        }

        public async Task<bool> DeleteMovieAsync(long movieId, long currentUserId)
        {
            var entity = await movieRepo.FirstAsync(x =>
                x.Id == movieId
                && x.UserId == currentUserId);
            if (entity == null) throw new Exception("Movie not exist!");

            movieRepo.Delete(entity);
            await unitOfWork.CommitAsync();
            return true;
        }

        public async Task<string> BeautifyLocalPathAsync(long movieId, long currentUserId)
        {
            var entity =
                await movieRepo.FirstAsync(x =>
                    x.Id == movieId
                    && x.UserId == currentUserId);
            if (entity == null) throw new Exception("Movie does not exist");

            var currentPath = entity.LocalPath;
            var invalidChars = Path.GetInvalidFileNameChars();
            var fileName = entity.Title;
            foreach (var invalidChar in invalidChars)
                fileName = fileName.Replace(invalidChar.ToString(), string.Empty);
            var newFileName = $"{fileName} [{entity.Year}] ({entity.ImdbRating})";
            var oldFileName = Path.GetFileName(currentPath);
            entity.LocalPath = entity.LocalPath.Replace(oldFileName, newFileName);

            movieRepo.Update(entity);
            await unitOfWork.CommitAsync();

            return newFileName;
        }

        public async Task<bool> SetSeenFlagAsync(long movieId, long currentUserId)
        {
            var entity = await movieRepo.FirstAsync(x => x.Id == movieId && x.UserId == currentUserId);
            if (entity == null) throw new Exception("Movie not found");

            entity.Seen = true;

            movieRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return true;
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