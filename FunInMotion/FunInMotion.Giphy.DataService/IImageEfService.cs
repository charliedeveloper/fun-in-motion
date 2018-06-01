namespace FunInMotion.Gif.DataService
{
    public interface IImageEfService
    {
        int Insert(Model.UserImageModel gif);
        bool UpdateImageCategory(int imageId, int categoryId);
        bool UpdateImageFavourite(int imageId, bool isFavourite);
    }
}