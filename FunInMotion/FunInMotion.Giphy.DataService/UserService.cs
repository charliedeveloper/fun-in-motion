using AutoMapper;
using FunInMotion.Gif.EF;
using FunInMotion.Gif.Model;
using FunInMotion.Gif.SharedCommon;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FunInMotion.Gif.DataService
{
    public class UserService : IUserService
    {
        GifCollectionEntities _context;

        public UserService(GifCollectionEntities userContext)
        {
            _context = userContext;
        }

        public Model.User GetUserByLogin(string loginName)
        {
            var user = _context.Users.AsNoTracking().Where(x => x.Login == loginName).FirstOrDefault();
            var searchUser = Mapper.Map<EF.User, Model.User>(user);
            return searchUser;
        }


        public int GetUserById(int id)
        {
            var user = _context.Users.AsNoTracking().Where(x => x.UserId == id).FirstOrDefault();
            var myUserId = user.UserId;
            return 1;
        }

        public List<Model.User> GetAllUsers()
        {
            var usersList =_context.Users.AsNoTracking().ToList();
            return Mapper.Map<List<EF.User>, List<Model.User>>(usersList);
        }

        public int AddUser(Model.User user)
        {
            var newUser = Mapper.Map<Model.User, EF.User>(user);
            _context.Users.Add(newUser);
            _context.SaveChanges();
            return newUser.UserId;
        }

        public void UpdateUser(List<EF.User> users)
        {
            _context.Configuration.AutoDetectChangesEnabled = false;
            foreach (var item in users)
            {
                _context.Users.Attach(item);
            }

            _context.ChangeTracker.DetectChanges();
            _context.FixState();
            _context.SaveChanges();


        }

        public bool IsUserExist(Model.UseViewModel user)
        {
            var loginUser = _context.Users.AsNoTracking().Where(x => x.Login == user.Login && x.Password == user.Password).FirstOrDefault();
            return loginUser != null;
        }

        public void UpdateUser(List<Model.User> users)
        {
            throw new NotImplementedException();
        }

        public List<UserImageModel> GetUserGaleries(int userId)
        {
            var userImageGallaries = _context.Gifs.AsNoTracking().Where(x => x.UserId == userId).OrderBy(x=>x.CategoryId).ToList();
            var galleries = Mapper.Map<List<EF.Gif>, List<UserImageModel>>(userImageGallaries);

            foreach (var item in galleries)
            {
                item.CategoryName = _context.Categories.AsNoTracking().Where(x => x.CategoryId == item.CategoryId)
                    .SingleOrDefault().CategoryName;
            }

            return galleries.ToList();
        }
    }
}
