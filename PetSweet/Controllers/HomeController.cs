using Microsoft.AspNetCore.Mvc;

namespace PetSweet.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AboutUs()
    {
        return View();
    }

}
