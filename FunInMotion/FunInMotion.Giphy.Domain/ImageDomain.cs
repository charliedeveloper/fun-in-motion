using FunInMotion.Gif.DataService;
namespace FunInMotion.Gif.DomainLogic
{
    public class ImageDomain : IImageDomain
    {

        IImageEfService _imageService;

        public ImageDomain(IImageEfService imageService)
        {
            _imageService = imageService;
        }

        public bool AddImageToGallery(Model.UserImageModel gif)
        {
            var returnId = _imageService.Insert(gif);
            return returnId > 0;
        }

        public bool UpdateImageCategory(int imageId, int categoryId)
        {
            return _imageService.UpdateImageCategory(imageId, categoryId);
        }

        public bool UpdateImageFavourite(int imageId, bool isFavourite)
        {
            return _imageService.UpdateImageFavourite(imageId, isFavourite);
        }
    }
}
