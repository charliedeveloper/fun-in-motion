using System.Collections.Generic;

namespace FunInMotion.Gif.DomainLogic
{
    public interface ICategoryDomain
    {
        List<Model.Category> GetCateroryList();
    }
}