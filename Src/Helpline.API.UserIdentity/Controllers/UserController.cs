using Helpline.Domain.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Helpline.API.UserIdentity.Controllers
{
    public class UserController : Controller
    {
        private readonly IApplicationUserRepository _userRepo;


        public UserController(IApplicationUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public IActionResult Register() => View();


    }
}
