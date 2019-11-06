using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Movie.Movie;

namespace AllInOne.Services.Contract.Movie
{
    public interface IMovieLib
    {
        Task<ImdbSearchModel> ImdbSearchAsync(InputImdbSearchModel model);
        Task<ImdbMovieModel> ImdbGetInfoByIdAsync(string imdbId);
        Task<bool> AddMovieFromImdbAsync(string imdbId, long currentUserId);
        Task<List<MovieModel>> GetMyMoviesAsync(long currentUserId);
    }
}