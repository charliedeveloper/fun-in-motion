namespace FunInMotion.Gif.Model
{
    public class UserImageModel
    {
        public int UserId { get; set; }
        public string SourceId { get; set; }
        public string ThumbnailSizeImageUrl { get; set; }
        public string LargeSizeImageUrl { get; set; }
        public string Rating { get; set; }
        public bool IsFavourite { get; set; }
        public int StarRating { get; set; }
        public int CategoryId { get; set; }
        public bool Action { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public string CategoryName { get; set; }
    }
}
