using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaDay.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("user/add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitAddUserForm(User newUser, string verify)
        {
            if (newUser.Password == verify)
            {
                ViewBag.newUser = newUser;
                return View("Index");
            }
            else
            {
                ViewBag.newUsername = newUser.Username;
                ViewBag.newEmail = newUser.Email;
                ViewBag.error = "Passwords Do Not Match";
                return View("Add");
            }
        }
    }
}
