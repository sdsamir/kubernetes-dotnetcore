using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using kubernetes.dotnet.presentation.Models;
using kubernetes.dotnet.domain.Entities;
using System.Text.Json;

namespace kubernetes.dotnet.presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public readonly IConfiguration _configuration;

    public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
    {
        _logger = logger?? throw new ArgumentNullException(nameof(logger));
        _configuration = configuration?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<IActionResult> Index()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage();
        var apiBaseUrl = _configuration.GetValue<string>("Api:BaseUrl");

        request.RequestUri = new Uri($"{apiBaseUrl}/Users");
        request.Method = HttpMethod.Get;

        var response = await client.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();

        var users = JsonSerializer.Deserialize<User[]>(result, new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        return View(users);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
