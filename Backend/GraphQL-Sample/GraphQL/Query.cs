using GraphQL.Sample.Models;
using GraphQL.Sample.Services;

namespace GraphQL.Sample.GraphQL;

public class Query
{
    private readonly UserService _userService;

    public Query(UserService userService)
    {
        _userService = userService;
    }

    public IList<User> GetUsers() => _userService.GetAll();

    public User? GetUser(int id) => _userService.Get(id);
}
