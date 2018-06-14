namespace Tamga.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Tamga.Models;
    using Tamga.Service;

    public class HomeController : Controller
    {
        
        private IUserService _userService;
        public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetUserForm()
        {
            return PartialView("UserForm", new UserViewModel());
        }

        public ActionResult GetListItem(UserViewModel user)
        {
            return PartialView("UserListItem", user);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetUser()
        {
            var users = _userService.GetUsers();
            return PartialView("UsersList", users);
        }
        
        [HttpPost]
        public ActionResult Save(List<UserViewModel> userList)
        {
            _userService.SaveUsers(userList);
            return new EmptyResult();
        }
    }
}