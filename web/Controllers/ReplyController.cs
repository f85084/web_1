using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;
using System.Web.Mvc;
using web.Data;
using System.Data.Entity;
using Reply = web.Models.Reply;


namespace webtext.web.Controllers
{
    public class ReplyController : Controller
    {
        public ActionResult Index()
        {
            ReplyWeb replyWeb = new ReplyWeb();
            List<Library.Reply> replys = replyWeb.Replys.ToList();
            return View(replys);
        }

        public ActionResult Details(int id = 0)
        {
            var WebContext = new webContext();
            Reply reply;
            if (id == 0)
            {
                reply = new Reply
                {
                    Id = 0,
                    UserId = 0,
                    UserName = "NULL",
                    Context = "NULL",
                };
            }
            else
            {
                reply = WebContext.Replys.Single(p => p.Id == id);
                //Throws exception if can not find the single entity
            }
            return View(reply);
        }

        /**建立**/
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Library.Reply reply)
        {
            if (!ModelState.IsValid)
            {
                return View("Create");
            }

            ReplyWeb replyWeb = new ReplyWeb();
            replyWeb.AddReply(reply);
            return RedirectToAction("Index");
        }

    }
}