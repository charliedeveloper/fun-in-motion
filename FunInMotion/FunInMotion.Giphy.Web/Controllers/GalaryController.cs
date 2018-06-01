using FunInMotion.Gif.DomainLogic;
using FunInMotion.Gif.Model;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
namespace FunInMotion.Gif.Web.Controllers
{
    [Authorize]
    public class GalaryController : Controller
    {
        IUserDomain _userDomain;
        IGiphyService _giphyService;
        IImageDomain _imageDomain;
        ICategoryDomain _categoryDomain;


        public GalaryController(IUserDomain userDomain,
            IGiphyService giphyService,
            IImageDomain imageDomain,
            ICategoryDomain categoryDomain)
        {
            _userDomain = userDomain;
            _giphyService = giphyService;
            _imageDomain = imageDomain;
            _categoryDomain = categoryDomain;
        }

        public ActionResult UpdateImageCategory(int imageId, int categoryid)
        {
            _imageDomain.UpdateImageCategory(imageId, categoryid);
            return this.Json(new
            {
                success = true,
                message = ""
            });
        }

        public ActionResult SetImageFavourite(int imageId, bool isFavourite)
        {
            _imageDomain.UpdateImageFavourite(imageId, isFavourite);
            return this.Json(new
            {
                success = true,
                message = "add"
            });
        }

        public ActionResult Index()
        {
            var categoryLookup = _categoryDomain.GetCateroryList();
            ViewBag.Category = new SelectList(categoryLookup, "CategoryId", "CategoryName"); ;

            var model = _userDomain.GetUserImageGalleries(User.Identity.GetUserName());
            return View(model);
        }

        public ActionResult UserGallery()
        {
            var model = new GalleryByCategoryViewModel();

            return View(model);
        }
    }
    
}