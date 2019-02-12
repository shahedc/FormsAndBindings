using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FormsAndBindings.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class AttrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index([FromQuery] string humanInfo)
        {
            ViewData["humanInfo"] = humanInfo;
            return View();
        }

        [HttpGet]
        public IActionResult Details([FromRoute] int id)
        {
            Human human = new Human
            {
                Id = id,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 ABC St",
                DateOfBirth = DateTime.Now,
                FavoriteNumber = 7,
                IsActive = true
            };

            return View(human);
        }

        [HttpPost]
        public IActionResult Details([FromForm] Human human)
        {
            var humanInfo = new StringBuilder();
            humanInfo.Append(human.FirstName + " " + human.LastName);
            humanInfo.Append(", Date of Birth: " + human.DateOfBirth.ToString("yyyy-MM-dd"));
            humanInfo.Append(", Id: " + human.Id + ", Favorite Number: " + human.FavoriteNumber);
            return RedirectToAction("index", new { humanInfo = humanInfo.ToString() });
        }
    }
}