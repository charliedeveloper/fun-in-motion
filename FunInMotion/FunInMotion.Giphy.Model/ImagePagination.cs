using System.Collections.Generic;

namespace FunInMotion.Gif.Model
{
    public class ImagePagination
    {
        public int NumberOfImages { get; set; }
        public int Offset { get; set; }
        public int TotalImages { get; set; }
        public string SearchTerm { get; set; }
        public List<UserImageModel> ImageCollection { get; set; }

        public ImagePagination()
        {
            ImageCollection = new List<UserImageModel>();
        }
    }
}
