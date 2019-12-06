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
    public class MovieCollectionController : BaseController
    {
        private readonly ICollectionLib collectionLib;

        public MovieCollectionController(
            ICollectionLib collectionLib
            )
        {
            this.collectionLib = collectionLib;
        }

        [HttpPost]
        public async Task<IActionResult> AddCollection([FromBody] AddCollectionInput model)
        {
            try
            {
                var result = await collectionLib.AddCollectionAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut]
        public async Task<IActionResult> AddMovieToCollection([FromBody] AddMovieToCollectionInput model)
        {
            try
            {
                var result = await collectionLib.AddMovieToCollectionAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete("{collectionId}")]
        public async Task<IActionResult> DeleteCollection(long collectionId)
        {
            try
            {
                var result = await collectionLib.DeleteCollectionAsync(collectionId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpPut]
        public async Task<IActionResult> EditCollection([FromBody] EditCollectionInput model)
        {
            try
            {
                var result = await collectionLib.EditCollectionAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCollections()
        {
            try
            {
                var result = await collectionLib.GetAllCollectionsAsync(CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpGet("collectionId")]
        public async Task<IActionResult> GetCollectionMovies(long collectionId)
        {
            try
            {
                var result = await collectionLib.GetCollectionMoviesAsync(collectionId, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMovieFromCollection([FromBody] RemoveMovieFromCollectionInput model)
        {
            try
            {
                var result = await collectionLib.RemoveMovieFromCollectionAsync(model, CurrentUserId);
                return CustomResult(result);
            }
            catch (System.Exception exp)
            {
                return CustomError(exp);
            }
        }
    }
}