using GiphyDotNet.Model.Results;
using System.Threading.Tasks;

namespace FunInMotion.Gif.Service
{
    public interface IGiphyApi
    {
        Task<GiphySearchResult> SearchGif(string searchterm, int offset = 0);
    }
}
