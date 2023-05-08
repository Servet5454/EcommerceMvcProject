using ECommerceWithMVC.Models;
using ECommerceWithMVC.Models.DataContext;
using ECommerceWithMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Diagnostics;

namespace ECommerceWithMVC.Controllers
{
    public class HomeController : BaseController
	{
        /// <summary>
        /// Dependency injection dan yararlanarak controller Tarafında kullanacağım temel nesneleri constructer'a veriyorum...
        /// </summary>
        private readonly IConfiguration configuration;
        private readonly ECommerceDBContext context;
        private readonly EntityCreater creater;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, ECommerceDBContext context, EntityCreater creater)
        {
            _logger = logger;
            this.configuration = configuration;
            this.context = context;
            this.creater = creater;
        }

        public IActionResult Anasayfa()
        {
            
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }
        
        public IActionResult Urun()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}