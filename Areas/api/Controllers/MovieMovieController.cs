using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.Movie.Movie;
using AllInOne.Services.Contract.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.api.Controllers
{
    [Route("api/[controller]/[action]")]
    [Area("api")]
    [ApiController]
    [Authorize]
    public class MovieMovieController : BaseController
    {
        private readonly IMovieLib movieLib;

        public MovieMovieController(
            IMovieLib movieLib
            )
        {
            this.movieLib = movieLib;
        }

        [HttpPost]
        public async Task<IActionResult> SearchImdbFilms([FromBody] InputImdbSearchModel model)
        {
            try
            {
                var result = await movieLib.ImdbSearchAsync(model);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost("{imdbId}")]
        public async Task<IActionResult> ImdbGetInfoById(string imdbId)
        {
            try
            {
                var result = await movieLib.ImdbGetInfoByIdAsync(imdbId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovieFromImdb([FromBody]AddMovieFromImdbInput model)
        {
            try
            {
                var result = await movieLib.AddMovieFromImdbAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost]
        public async Task<IActionResult> GetMyMovies(GetMyMoviesFilter model)
        {
            try
            {
                var result = await movieLib.GetMyMoviesAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> DeleteMovie(long movieId)
        {
            try
            {
                var result = await movieLib.DeleteMovieAsync(movieId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    
        [HttpPost("{movieId}")]
        public async Task<IActionResult> BeautifyLocalPath(long movieId)
        {
            try
            {
                var result = await movieLib.BeautifyLocalPathAsync(movieId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        
        }
    
        [HttpPut("{movieId}")]
        public async Task<IActionResult> SetSeenFlag(long movieId)
        {
            try
            {
                var result = await movieLib.SetSeenFlagAsync(movieId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLocalPaths()
        {
            try
            {
                var result = await movieLib.GetAllLocalPathsAsync(CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPost("{movieId}")]
        public async Task<IActionResult> GetMovie(long movieId)
        {
            try
            {
                var result = await movieLib.GetMovieAsync(movieId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}