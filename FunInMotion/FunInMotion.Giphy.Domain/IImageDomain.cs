namespace FunInMotion.Gif.DomainLogic
{
    public interface IImageDomain
    {
        bool AddImageToGallery(Model.UserImageModel gif);
        bool UpdateImageCategory(int imageId, int categoryId);
        bool UpdateImageFavourite(int imageId, bool isFavourite);
    }
}