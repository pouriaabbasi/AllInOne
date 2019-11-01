using System.Threading.Tasks;
using AllInOne.Areas.api.Controllers.Base;
using AllInOne.Models.LeitnerBox.Box;
using AllInOne.Models.Movie.Movie;
using AllInOne.Services.Contract.LeitnerBox;
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
                var result = await movieLib.ImdbSearch(model);
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
                var result = await movieLib.ImdbGetInfoById(imdbId);
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
                var result = await movieLib.AddMovieFromImdb(imdbId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}