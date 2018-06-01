using AutoMapper;
using FunInMotion.Gif.EF;
using System.Linq;
using System;

namespace FunInMotion.Gif.DataService
{
    public class ImageEfService: IImageEfService
    {
        GifCollectionEntities _context;

        public ImageEfService(GifCollectionEntities context)
        {
            _context = context;
        }

        public int Insert(Model.UserImageModel gif)
        {
            var newGif = Mapper.Map<Model.UserImageModel, EF.Gif>(gif);
            _context.Gifs.Add(newGif);
            _context.SaveChanges();
            return newGif.ImageId;
        }

        public bool UpdateImageCategory(int imageId, int CategoryId)
        {
            var selectedImage = _context.Gifs.SingleOrDefault(x => x.ImageId == imageId);
            selectedImage.CategoryId = CategoryId;
            _context.Entry(selectedImage).CurrentValues.SetValues(CategoryId);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateImageFavourite(int imageId, bool isFavourite)
        {
            var selectedImage = _context.Gifs.SingleOrDefault(x => x.ImageId == imageId);
            selectedImage.IsFavourite = isFavourite;
            _context.Entry(selectedImage).CurrentValues.SetValues(isFavourite);
            _context.SaveChanges();

            return true;
        }
    }
}
