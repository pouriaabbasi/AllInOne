using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllInOne.Data;
using AllInOne.Data.Entity.Moive;
using AllInOne.Models.Movie.Movie;
using AllInOne.Services.Contract.Movie;

namespace AllInOne.Services.Implementation.Movie
{
    public class CollectionLib : ICollectionLib
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<MovieCollection> collectionMovieRepo;
        private readonly IRepository<Data.Entity.Moive.Movie> movieRepo;
        private readonly IRepository<MovieCollectionDetail> movieCollectionDetailRepo;

        public CollectionLib(
            IUnitOfWork unitOfWork,
            IRepository<MovieCollection> collectionMovieRepo,
            IRepository<Data.Entity.Moive.Movie> movieRepo,
            IRepository<MovieCollectionDetail> movieCollectionDetailRepo)
        {
            this.unitOfWork = unitOfWork;
            this.collectionMovieRepo = collectionMovieRepo;
            this.movieRepo = movieRepo;
            this.movieCollectionDetailRepo = movieCollectionDetailRepo;
        }

        public async Task<CollectionModel> AddCollectionAsync(AddCollectionInput model, long currentUserId)
        {
            var entity = new MovieCollection
            {
                Name = model.Name,
                UserId = currentUserId
            };

            await collectionMovieRepo.AddAsync(entity);

            return ConvertEntityToCollectionModel(entity);
        }

        public async Task<bool> AddMovieToCollectionAsync(AddMovieToCollectionInput model, long currentUserId)
        {
            var collectionEntity = await collectionMovieRepo.FirstAsync(x =>
                x.Id == model.CollectionId
                && x.UserId == currentUserId);
            if (collectionEntity == null)
                throw new System.Exception("Collection not exist");

            var movieEntity = await movieRepo.FirstAsync(x =>
                x.Id == model.MovieId
                && x.UserId == currentUserId);
            if (movieEntity == null)
                throw new System.Exception("Movie not exist");

            if (collectionEntity.MovieCollectionDetails.Any(x => x.MovieId == model.MovieId))
                throw new System.Exception("Movie is exist in collection");

            collectionEntity.MovieCollectionDetails.Add(new MovieCollectionDetail
            {
                MovieId = model.MovieId,
                Number = model.Number
            });

            collectionMovieRepo.Update(collectionEntity);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> DeleteCollectionAsync(long collectionId, long currentUserId)
        {
            var entity = await collectionMovieRepo.FirstAsync(x =>
                x.Id == collectionId
                && x.UserId == currentUserId);

            if (entity == null) throw new System.Exception("Collection is not exist");

            collectionMovieRepo.Delete(entity);
            await unitOfWork.CommitAsync();

            return true;
        }

        public async Task<CollectionModel> EditCollectionAsync(EditCollectionInput model, long currentUserId)
        {
            var entity = await collectionMovieRepo.FirstAsync(x =>
                x.Id == model.Id
                && x.UserId == currentUserId);

            if (entity == null) throw new System.Exception("Collection is not exist");

            entity.Name = model.Name;

            collectionMovieRepo.Update(entity);

            await unitOfWork.CommitAsync();

            return ConvertEntityToCollectionModel(entity);
        }

        public async Task<List<CollectionModel>> GetAllCollectionsAsync(long currentUserId)
        {
            var result = await collectionMovieRepo.GetQuery()
                .Where(x => x.UserId == currentUserId)
                .OrderBy(x => x.Name)
                .Select(x => new CollectionModel
                {
                    Id = x.Id,
                    Name = x.Name
                })
                .ToAsyncEnumerable()
                .ToList();

            return result;
        }

        public async Task<CollectionMoviesModel> GetCollectionMoviesAsync(long collectionId, long currentUserId)
        {
            var entity = await collectionMovieRepo.FirstAsync(x =>
                x.Id == collectionId
                && x.UserId == currentUserId);
            if (entity == null) throw new System.Exception("Collection is not exist");

            var result = new CollectionMoviesModel
            {
                CollectionId = entity.Id,
                Name = entity.Name
            };

            result.CollectionDetails = entity.MovieCollectionDetails
                .Select(x => new CollectionDetailModel
                {
                    CollectionDetailId = x.Id,
                    MovieName = x.Movie.Title,
                    Number = x.Number
                })
                .ToList();

            return result;
        }

        public async Task<bool> RemoveMovieFromCollectionAsync(RemoveMovieFromCollectionInput model, long currentUserId)
        {
            var entity = await movieCollectionDetailRepo.FirstAsync(x =>
                x.MovieCollectionId == model.CollectionId
                && x.MovieId == model.MovieId
                && x.MovieCollection.UserId == currentUserId);
            if (entity == null) throw new System.Exception("not exist");

            movieCollectionDetailRepo.Delete(entity);
            await unitOfWork.CommitAsync();

            return true;
        }

        private CollectionModel ConvertEntityToCollectionModel(MovieCollection entity)
        {
            return new CollectionModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}