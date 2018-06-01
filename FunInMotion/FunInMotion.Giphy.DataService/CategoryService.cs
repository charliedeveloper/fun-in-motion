using AutoMapper;
using FunInMotion.Gif.EF;
using System.Collections.Generic;
using System.Linq;

namespace FunInMotion.Gif.DataService
{
    public class CategoryService : ICategoryService
    {
        GifCollectionEntities _context;

        public CategoryService(GifCollectionEntities context)
        {
            _context = context;
        }

        public List<Model.Category> GetAllCategories()
        {
            var categories = _context.Categories.AsNoTracking().ToList();
            return Mapper.Map<List<EF.Category>, List<Model.Category>>(categories);
        }
    }
}
