using System.Collections.Generic;

namespace FunInMotion.Gif.Model
{
    public interface IUserDomain
    {
        bool InsertUser(Model.User user);
        List<Model.User> Users();
        bool IsAccountExist(string loginName);
        bool AuthenticateUser(Model.UseViewModel user);
        User GetUserByLoginName(string loginName);
        List<UserImageModel> GetUserImageGalleries(string userName);
        List<GalleryByCategoryViewModel> GetUserImageGalleriesByCategory(string userName);
    }
}
