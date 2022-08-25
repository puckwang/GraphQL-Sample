using GraphQL.Sample.Models;
using GraphQL.Sample.Repositories;

namespace GraphQL.Sample.GraphQL;

public class Mutation
{
    private readonly UserRepository _userRepository;

    public Mutation(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User CreateUser(CreateUser user) => _userRepository.Create(user);
}
