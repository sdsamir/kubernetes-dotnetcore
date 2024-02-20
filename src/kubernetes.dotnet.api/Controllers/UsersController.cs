using kubernetes.dotnet.domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace kubernetes.dotnet.api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController:ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger?? throw new ArgumentNullException(nameof(logger));
    }


    [AllowAnonymous]
    [HttpGet]
    public IEnumerable<User> Get()
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

        return users;
    }
}