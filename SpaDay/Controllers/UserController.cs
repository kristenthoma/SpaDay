using Microsoft.AspNetCore.Mvc;
using SpaDay.Models;
using SpaDay.ViewModels;
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
            AddUserViewModel addUserViewModel = new AddUserViewModel();

            return View(addUserViewModel);
        }

        [HttpPost]
        public IActionResult SubmitAddUserForm(AddUserViewModel addUserViewModel)
        {

            if (ModelState.IsValid)
            {
                if (addUserViewModel.Password == addUserViewModel.VerifyPassword)
                {
                    User newUser = new User
                    {
                        Username = addUserViewModel.Username,
                        Email = addUserViewModel.Email,
                        Password = addUserViewModel.Password,
                        VerifyPassword = addUserViewModel.VerifyPassword
                    };

                    return View("Index", addUserViewModel);
                }

                else
                {
                    User newUser = new User
                    {
                        Username = addUserViewModel.Username,
                        Email = addUserViewModel.Email,
                    };

                    ViewBag.error = "Passwords Do Not Match";

                    return View("Add", addUserViewModel);
                }

            }

            return View("Add");
        }
    }
}
