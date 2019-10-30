using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using AllInOne.Models.Movie.Movie;
using AllInOne.Services.Contract.Movie;
using Newtonsoft.Json;

namespace AllInOne.Services.Implementation.Movie
{
    public class MovieLib : IMovieLib
    {
        const string _omdbApiKey = "c651206f";
        const string _baseUrl = "http://www.omdbapi.com/?";
        public async Task<ImdbSearchModel> ImdbSearch(InputImdbSearchModel model)
        {
            var url = model.CreateRequestUrl(_baseUrl, _omdbApiKey);
            return await GetAsync<ImdbSearchModel>(url);
        }

        public async Task<T> GetAsync<T>(string uri)
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