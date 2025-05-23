using HostCloudMVC.Bl.Services;
using HostCloudMVC.Bl.ViewModels;
using HostCloudMVC.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace HostCloudMVC.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CloudController : Controller
    {
        public readonly CloudService _cloudService;

        public CloudController(CloudService cloudService)
        {
            _cloudService = cloudService;
        }

        public IActionResult Index()
        {
            List<Cloud> clouds = _cloudService.GetAllCloud();
            return View(clouds);
        }
        [HttpGet]
        public IActionResult Info(int id)
        {
            Cloud cloud=_cloudService.GetCloudById(id);
            return View(cloud);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CloudVM cloudVm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
          
            _cloudService.CreateCloud(cloudVm);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var model=_cloudService.GetCloudById(id);
            var viewmodel = new CloudVM()
            {
                Name = model.Name,
                Description = model.Description,
            };
            return View(viewmodel);
        }
        [HttpPost]
        public IActionResult Update(int id, CloudVM cloudVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }


            _cloudService.UpdateCloud(id, cloudVM);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _cloudService.DeleteCloud(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
