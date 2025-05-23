using Microsoft.AspNetCore.Mvc;

namespace SpartanVStoreApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Dashboard
        public IActionResult Dashboard()
        {
            // Check if user is authenticated
            if (TempData["IsAuthenticated"] == null || !(bool)TempData["IsAuthenticated"])
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }
    }
}
