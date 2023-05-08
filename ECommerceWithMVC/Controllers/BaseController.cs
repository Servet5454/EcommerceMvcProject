using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerceWithMVC.Controllers
{

	public class BaseController : Controller
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			string layoutName = GetLayoutName();
			if (!string.IsNullOrEmpty(layoutName))
			{
				ViewBag.Layout = "~/Views/Shared/" + layoutName + ".cshtml";
			}
		}

		private string GetLayoutName()
		{
			string layoutName = "_Layout"; // varsayılan layout adı
			if (HttpContext.User.IsInRole("Admin"))
			{
				layoutName = "_LayoutAdmin";
			}
			return layoutName;
		}
	}


}

