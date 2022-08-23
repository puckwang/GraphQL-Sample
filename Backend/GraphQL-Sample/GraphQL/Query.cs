using GraphQL.Sample.Models;
using GraphQL.Sample.Repositories;

namespace GraphQL.Sample.GraphQL;

public class Query
{
    private readonly UserRepository _userRepository;

    public Query(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetUsers() => _userRepository.GetAll();

    public User? GetUser(int id) => _userRepository.Get(id);
}
