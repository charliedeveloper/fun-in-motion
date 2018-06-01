using FunInMotion.Gif.Model;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace FunInMotion.Gif.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        IUserDomain _userDomain;


        public AccountController(IUserDomain userDomain)
        {
            _userDomain = userDomain;
        }

        // GET: Account
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(FunInMotion.Gif.Model.User user)
        {
            if (ModelState.IsValid)
            {
                //Query if the user/account already taken
                if (!_userDomain.IsAccountExist(user.Login))
                {
                    //Add new user account
                    _userDomain.InsertUser(user);
                    FormsAuthentication.SetAuthCookie(user.Login, false);
                    return RedirectToAction("Welcome", "Home");
                }
                else
                {
                    ModelState.AddModelError("AccountExist","Login name is already exist!");
                }

            }

            return View();
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [Authorize]
        public ActionResult SignOut()
        {
            //Response.Cache.SetExpires(DateTime.Now);
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //FormsAuthentication.SignOut();
            //Session.Abandon();
            //Response.Cookies.Clear();

            FormsAuthentication.SignOut();
            HttpContext.User = new GenericPrincipal(new GenericIdentity(string.Empty), null);
            Session.Abandon();
            FormsAuthentication.RedirectToLoginPage();
            HttpContext.ApplicationInstance.CompleteRequest();
            return RedirectToAction("LogIn");
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(FunInMotion.Gif.Model.UseViewModel user)
        {
            if (ModelState.IsValid)
            {
                //Check if the user exist
                var isValidUser = _userDomain.AuthenticateUser(user);
                if (!isValidUser)
                {
                    ModelState.AddModelError("LoginError", "Login name or password provided is incorrect.");
                    return View();
                }
                else
                {
                    FormsAuthentication.RedirectFromLoginPage(user.Login, false);
                }
            }
            return View();
        }
    }
}