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
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            UserWeb userWeb = new UserWeb();
            List<Library.User> users = userWeb.Users.ToList();
            return View(users);
        }

        public ActionResult Details(int id)
        {
            var WebContext = new webContext();
            User user;
            if (id == 0)
            {
                user = new User
                {
                    Id = 0,
                    UserAccount = "Name0",
                    UserClass = "NULL",
                    Email = "NULL",
                    Password = "NULL",
                    UserName = "NULL"
                };
            }
            //else
            //{
            //    user = WebContext.Users.Single(p => p.Id == id);
            //    //UserWeb userWeb = new UserWeb();
            //    //Library.User user = userWeb.Users.Single(g => g.Id == id);

            //    //Throws exception if can not find the single entity
            //}
            return View();
        }

        /**建立**/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.User user)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            UserWeb userWeb = new UserWeb();
            userWeb.AddUser(user);
            return RedirectToAction("Index");
        }

        /**更新讀取**/
        [HttpGet]
        public ActionResult Edit(int id)
        {
            UserWeb userWeb = new UserWeb();
            Library.User user = userWeb.Users.Single(g => g.Id == id);
            return View(user);
        }

        /**更新動作**/
        [HttpPost]
        public ActionResult Edit([Bind(Include = "UserAccount, UserClass, Email, Password, UserName")]Library.User user)
        {
            UserWeb userWeb = new UserWeb();
            user.Id = userWeb.Users.Single(g => g.Id == user.Id).Id;

            if (!ModelState.IsValid)
            {
                return View("Edit", user);
            }

            userWeb.SaveUser(user);

            return RedirectToAction("Index");
        }

        /**刪除動作**/
        [HttpPost]
        public ActionResult Delete(int id)
        {
            UserWeb userWeb = new UserWeb();
            userWeb.DeleteUser(id);
            return RedirectToAction("Index");
        }

    }
}
