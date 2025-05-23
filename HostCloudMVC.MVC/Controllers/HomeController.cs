using HostCloudMVC.Bl.Services;
using HostCloudMVC.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HostCloudMVC.MVC.Controllers;

public class HomeController : Controller
{
    private readonly CloudService _cloudService;

    public HomeController(CloudService cloudService)
    {
        _cloudService = cloudService;
    }

    public IActionResult Index()
    {
        List<Cloud> clouds = _cloudService.GetAllCloud();
        return View(clouds);
    }
}
