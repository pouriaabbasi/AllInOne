using System.Collections.Generic;
using System.Threading.Tasks;
using AllInOne.Models.Movie.Movie;

namespace AllInOne.Services.Contract.Movie
{
    public interface ICollectionLib
    {
         Task<CollectionModel> AddCollectionAsync(AddCollectionInput model, long currentUserId);
         Task<CollectionModel> EditCollectionAsync(EditCollectionInput model, long currentUserId);
         Task<bool> DeleteCollectionAsync(long collectionId, long currentUserId);
         Task<List<CollectionModel>> GetAllCollectionsAsync(long currentUserId);
         Task<bool> AddMovieToCollectionAsync(AddMovieToCollectionInput model, long currentUserId);
         Task<bool> RemoveMovieFromCollectionAsync(RemoveMovieFromCollectionInput model, long currentUserId);
         Task<CollectionMoviesModel> GetCollectionMoviesAsync(long collectionId, long currentUserId);

    }
}