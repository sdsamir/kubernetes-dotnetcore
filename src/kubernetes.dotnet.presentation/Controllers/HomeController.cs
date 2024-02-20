using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kubernetes.dotnet.presentation.Models;
using kubernetes.dotnet.domain.Entities;

namespace kubernetes.dotnet.presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        IEnumerable<User> users =new List<User>()
        {
            new User()
            {
                Id = 1,
                FirstName = "Samir",
                LastName = "Dutta",
                Description = "This is a test User",
                CreatedDate = DateTime.UtcNow,
                EditedDate = null,
                DeletedDate = null,
            }
        };
        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
