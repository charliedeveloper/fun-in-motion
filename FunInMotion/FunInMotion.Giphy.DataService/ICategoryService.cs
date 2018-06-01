using System.Collections.Generic;

namespace FunInMotion.Gif.DataService
{
    public interface ICategoryService
    {
        List<Model.Category> GetAllCategories();
    }
}