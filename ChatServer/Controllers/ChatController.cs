using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ChatServer.Models;

namespace ChatServer.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View(new ChatModel
            {
                Messages = ChatStorage._msgs,
                Users = ChatStorage._users
            });
        }
    }
}