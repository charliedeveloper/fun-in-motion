using FunInMotion.Gif.DataService;
using System;
using System.Collections.Generic;

namespace FunInMotion.Gif.Model
{
    public class UserDomain : IUserDomain
    {
        IUserService _userService;
    
        public UserDomain(IUserService userService)
        {
            _userService = userService;
        }

        public bool InsertUser(Model.User user)
        {
            var returnId = _userService.AddUser(user);
            return returnId > 0;
        }

        public List<Model.User> Users()
        {
            return _userService.GetAllUsers();

        }

        public bool UpdateMultiUser()
        {
            //var usersList = new List<User>();
            ////usersList.Add(new User { UserId =1 , Lastname="User1", Password="password" })
            //_userService.UpdateUser(usersList);
            return true;
        }

        public bool IsAccountExist(string loginName)
        {
           return  _userService.GetUserByLogin(loginName) != null;
        }

        public bool AuthenticateUser(UseViewModel user)
        {
            return _userService.IsUserExist(user);
        }

        public User GetUserByLoginName(string loginName)
        {
            return _userService.GetUserByLogin(loginName);
        }

        public List<UserImageModel> GetUserImageGalleries(string userName)
        {
            var user = GetUserByLoginName(userName);
            return _userService.GetUserGaleries(user.UserId);
        }

        public List<GalleryByCategoryViewModel> GetUserImageGalleriesByCategory(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
