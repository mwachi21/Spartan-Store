using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SpartanVStoreApp.Controllers
{
    public class AccountController : Controller
    {
        // Simulated database for demonstration purposes
        private static List<(string Username, string Password)> users = new();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Check if user exists
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != default)
            {
                // Simulate setting a session or authentication cookie
                TempData["IsAuthenticated"] = true;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password.";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(string username, string password)
        {
            // Add user to simulated database
            users.Add((username, password));
            TempData["IsAuthenticated"] = true;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            // Clear session or authentication logic
            TempData["IsAuthenticated"] = null;
            return RedirectToAction("Login");
        }

        public IActionResult Dashboard()
        {
            if (TempData["IsAuthenticated"] == null || !(bool)TempData["IsAuthenticated"])
            {
                return RedirectToAction("Login");
            }
