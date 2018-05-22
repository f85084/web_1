using System;
using System.Collections.Generic;
using System.Linq;
using Library;
using System.Web.Mvc;
using web.Data;
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

        public ActionResult Details(int id = 0)
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
            else
            {
                user = WebContext.Users.Single(p => p.Id == id);
                //Throws exception if can not find the single entity
            }
            return View(user);
        }

        //[HttpGet] attribute means it only respond to the "GET" request. 
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
            userWeb.AddGamer(user);
            return RedirectToAction("Index");
        }

    }
}
