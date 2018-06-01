using FunInMotion.Gif.DomainLogic;
using FunInMotion.Gif.Model;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace FunInMotion.Gif.Web.Controllers
{
    [Authorize]
    public class GiphyController : Controller
    {
        IUserDomain _userDomain;
        IGiphyService _giphyService;
        IImageDomain _imageDomain;


        public GiphyController(IUserDomain userDomain, 
            IGiphyService giphyService,
            IImageDomain imageDomain)
        {
            _userDomain = userDomain;
            _giphyService = giphyService;
            _imageDomain = imageDomain;
        }


        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            var model = await _giphyService.SearchGif("Dog");
            ViewBag.PageInformation = _giphyService.GetPageInformation(model);
            return View(model);
        }

        [HttpPost]
        public async System.Threading.Tasks.Task<ActionResult> Search(string searchterm)
        {
            var model = await _giphyService.SearchGif(searchterm);
            ViewBag.PageInformation = _giphyService.GetPageInformation(model);
            return PartialView("_SearchResult", model);
        }

        [HttpPost]
        public ActionResult AddToFavourites(bool addedtofavourite, string smallimageurl, string largeImageUrl) //This must be replace with a model
        {
            //TEMP ONLY
            var selectedImage = new UserImageModel
            {
                CategoryId = 1,
                IsFavourite = addedtofavourite,
                ThumbnailSizeImageUrl = smallimageurl,
                 LargeSizeImageUrl = largeImageUrl,
                UserId = _userDomain.GetUserByLoginName(User.Identity.GetUserName()).UserId
            };

            _imageDomain.AddImageToGallery(selectedImage);

            return this.Json(new
            {
                success = true,
                message = addedtofavourite ? "add" : ""
            });
        }

     

        [HttpPost]
        public ActionResult AddToGallery(UserImageModel selectedImage)
        {
            selectedImage.IsFavourite = false;
            selectedImage.UserId = _userDomain.GetUserByLoginName(User.Identity.GetUserName()).UserId;
            _imageDomain.AddImageToGallery(selectedImage);
            return this.Json(new
            {
                success = true,
                message = ""
            });
        }

    }
}