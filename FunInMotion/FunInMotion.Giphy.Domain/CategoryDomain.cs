using FunInMotion.Gif.DataService;
using FunInMotion.Gif.Model;
using System.Collections.Generic;

namespace FunInMotion.Gif.DomainLogic
{
    public class CategoryDomain : ICategoryDomain
    {
        ICategoryService _category;
        public CategoryDomain(ICategoryService category)
        {
            _category = category;
        }
        public List<Category> GetCateroryList()
        {
            return _category.GetAllCategories();
        }
    }
}
