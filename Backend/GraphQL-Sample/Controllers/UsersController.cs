using GraphQL.Sample.Models;
using GraphQL.Sample.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Sample.Controllers;

[ApiController]
[Route("Api/Users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _userService.GetAll();
    }

    [HttpGet("{id}")]
    public User? Get(int id)
    {
        return _userService.Get(id);
    }
}
