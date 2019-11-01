using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Movie.Movie;

namespace AllInOne.Services.Contract.Movie
{
    public interface IMovieLib
    {
        Task<ImdbSearchModel> ImdbSearch(InputImdbSearchModel model);
        Task<ImdbMovieModel> ImdbGetInfoById(string imdbId);
        Task<bool> AddMovieFromImdb(string imdbId, long currentUserId);
    }
}