using GraphQL.Sample.Models;
using GraphQL.Sample.Services;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.Sample.Controllers;

[ApiController]
[Route("Api/Users")]
public class UsersController : ControllerBase
{
    private readonly UserServices _userServices;

    public UsersController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _userServices.GetAll();
    }

    [HttpGet("{id}")]
    public User? Get(int id)
    {
        return _userServices.Get(id);
    }
}
