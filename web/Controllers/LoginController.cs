using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using System.Web.Mvc;
using web.Data;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using User = web.Models.User;

namespace webtext.web.Controllers
{
    public class LoginController : Controller
    {
        /**登入驗證**/
        [HttpPost]
        public ActionResult Login(string UserAccount, string Password)
        {
            Login service = new Login();
            //驗證登入資訊是否有對應之使用者
            var userInfo = service.GetUser(account, password);
            if (userInfo == null)
            {
                //如無對應使用者導頁
                return RedirectToAction("Signup");
            }

            //儲存使用者資訊
            ClaimsIdentity identity = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, userInfo.Name),
                new Claim("Id", userInfo.Id),
                new Claim(ClaimTypes.Role, userInfo.Group)
            },
            "AuthorizeDemoCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);
            //通過驗證者導頁
            return RedirectToAction("IndexPro");
        }
    }