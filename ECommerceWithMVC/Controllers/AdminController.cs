using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceWithMVC.Controllers
{
	[Authorize(Roles = "Admin")]
	public class AdminController : BaseController
	{
       
        public IActionResult AdminAnasayfa()
        {
            return View();
        }

        public IActionResult AdminProduct()
        {
            return View();
        }
        public IActionResult AddProduct()
        {
            return View();
        }
    }
}
