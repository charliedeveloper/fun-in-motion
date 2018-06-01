using FunInMotion.Gif.Model;
using System.Collections.Generic;

namespace FunInMotion.Gif.DataService
{
    public interface IUserService
    {
        int GetUserById(int id);
        int AddUser(Model.User user);
        void UpdateUser(List<Model.User> users);
        List<Model.User> GetAllUsers();
        Model.User GetUserByLogin(string loginName);
        bool IsUserExist(Model.UseViewModel user);
        List<UserImageModel> GetUserGaleries(int userId);
    }
}
