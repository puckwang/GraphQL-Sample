using GraphQL.Sample.Models;
using GraphQL.Sample.Repositories;

namespace GraphQL.Sample.GraphQL.TypeExtensions;

[ExtendObjectType(typeof(User))]
public class UserTypeExtensions
{
    private readonly UserRepository _userRepository;

    public UserTypeExtensions(UserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public IEnumerable<User> GetFriends([Parent] User user)
    {
        return _userRepository.GetFriends(user.Id);
    }
    
    public Role GetRole([Parent] User user)
    {
        return _userRepository.GetRole(user.Id);
    }
}
