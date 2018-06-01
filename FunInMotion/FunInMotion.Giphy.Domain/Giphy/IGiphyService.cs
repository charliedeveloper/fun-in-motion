using FunInMotion.Gif.Model;
using System.Threading.Tasks;

namespace FunInMotion.Gif.DomainLogic
{
    public interface IGiphyService
    {
        Task<ImagePagination> SearchGif(string searchterm);
        string GetPageInformation(ImagePagination model);
    }
}
