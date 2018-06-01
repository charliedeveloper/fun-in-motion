using System.Collections.Generic;

namespace FunInMotion.Gif.Model
{
    public class GalleryByCategoryViewModel
    {
        public Category ImageCategory { get; set; }
        public List<ImagePagination> ImagesInCategory { get; set; }
    }
}
