using Microsoft.AspNetCore.Mvc;

namespace PetSweet.Controllers;

public class AccountController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}
