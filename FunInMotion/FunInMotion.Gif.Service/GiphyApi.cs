using GiphyDotNet.Manager;
using GiphyDotNet.Model.Parameters;
using GiphyDotNet.Model.Results;
using System.Threading.Tasks;

namespace FunInMotion.Gif.Service
{
    public class GiphyApi : IGiphyApi
    {
        private const string ApiKey = "itgHunoAv2zgpe4MieCvKlcAHdMD6ZIN";

        public async Task<GiphySearchResult> SearchGif(string searchterm, int offset=0)
        {
            var giphy = new Giphy(ApiKey);
            var searchParameter = DefaultSearchParameter(searchterm);
            return await giphy.GifSearch(searchParameter);
        }

        private SearchParameter DefaultSearchParameter(string searchterm="funny", int offset=0)
        {
            return new SearchParameter()
            {
                Query = searchterm,
                Limit = 12,
                Offset = offset * 12,
                Rating = Rating.G
            };
        }
    }
}
