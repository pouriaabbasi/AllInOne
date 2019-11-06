using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.Movie.Movie;
using AllInOne.Services.Contract.Movie;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AllInOne.Areas.api.Controllers
{
    // [Route("api/[controller]/[action]")]
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

        [HttpPost("{imdbId}")]
        public async Task<IActionResult> AddMovieFromImdb(string imdbId)
        {
            try
            {
                var result = await movieLib.AddMovieFromImdbAsync(imdbId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMyMovies()
        {
            try
            {
                var result = await movieLib.GetMyMoviesAsync(CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}