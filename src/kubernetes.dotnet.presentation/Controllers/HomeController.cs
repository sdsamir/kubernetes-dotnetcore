using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kubernetes.dotnet.presentation.Models;
using kubernetes.dotnet.domain.Entities;
using System.Text.Json;

namespace kubernetes.dotnet.presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        request.RequestUri = new Uri("https://localhost:7254/Users");
        request.Method = HttpMethod.Get;

        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        var users = JsonSerializer.Deserialize<User[]>(result, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

        //var users = JsonConvert.DeserializeObject<List<clsSalesTran>>(inputString);

        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
