using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Movie.Movie;

namespace AllInOne.Services.Contract.Movie
{
    public interface IMovieLib
    {
        Task<ImdbSearchModel> ImdbSearchAsync(InputImdbSearchModel model);
        Task<ImdbMovieModel> ImdbGetInfoByIdAsync(string imdbId);
        Task<string> AddMovieFromImdbAsync(AddMovieFromImdbInput model, long currentUserId);
        Task<List<MovieModel>> GetMyMoviesAsync(GetMyMoviesFilter filter, long currentUserId);
        Task<bool> DeleteMovieAsync(long movieId, long currentUserId);
        Task<string> BeautifyLocalPathAsync(long movieId, long currentUserId);
        Task<bool> SetSeenFlagAsync(long movieId, long currentUserId);
    }
}