using Microsoft.AspNetCore.Mvc;

namespace HostCloudMVC.MVC.Controllers;

public class AccountController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
