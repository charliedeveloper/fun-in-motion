using FunInMotion.Gif.Model;
using FunInMotion.Gif.Service;
using System;
using System.Threading.Tasks;

namespace FunInMotion.Gif.DomainLogic
{
    public class GiphyService : IGiphyService
    {
        IGiphyApi _gyphyApi;
        public GiphyService(IGiphyApi gyphyApi)
        {
           _gyphyApi = gyphyApi;
        }

        public string GetPageInformation(ImagePagination model)
        {
            return $"Page {model.Offset + 1} of {(model.TotalImages / model.NumberOfImages) + ((model.TotalImages % model.NumberOfImages)>0?1:0)}";
        }

        public async Task<ImagePagination> SearchGif(string searchterm)
        {
           if (string.IsNullOrWhiteSpace(searchterm)) return new ImagePagination();

           var searchresult = new ImagePagination();
            try
            {
                var result = await _gyphyApi.SearchGif(searchterm);
                searchresult.NumberOfImages = result.Pagination.Count;
                searchresult.TotalImages = result.Pagination.TotalCount;
                searchresult.Offset = result.Pagination.Offset;

                foreach (var item in result.Data)
                {
                    searchresult.ImageCollection.Add(
                        new UserImageModel
                        {
                            ThumbnailSizeImageUrl = item.Images.Downsized.Url,
                            LargeSizeImageUrl = item.Images.Original.Url,
                            SourceId = Guid.NewGuid().ToString(),
                            Name = string.IsNullOrEmpty(item.Caption) ? "No caption available" : item.Caption,
                        });
                }
            }
            catch (System.Exception)
            {
                //Handel exception
                throw;
            }

            return searchresult;
        }
    }
}
