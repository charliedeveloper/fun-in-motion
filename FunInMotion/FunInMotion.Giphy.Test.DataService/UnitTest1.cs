using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FunInMotion.Gif.Test.DataService
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void InsertUserAndReturnNewlyAddedUser()
        {
            ////Arrange
            //var newUserInMemory = new List<User>();
            //var mockNewUser = new Mock<DbSet<User>>();
            //var userContext = new GifCollectionEntities { Users = mockNewUser.Object };
            //mockNewUser.Setup(m => m.Add(It.IsAny<User>())).Callback<User>(newUserInMemory.Add);

            ////Act
            //var service = new UserService(userContext);
            //var returnAfterInsert = service.AddUser(new Model.User { UserId = 100, Firstname = "Charlie" });

            ////Assert
            //Assert.IsInstanceOfType(returnAfterInsert, typeof(User));
            //Assert.AreEqual(returnAfterInsert, newUserInMemory.Find(x => x.UserId == 100).UserId);
        }
    }
}
