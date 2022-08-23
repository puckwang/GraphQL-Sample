using Bogus;
using GraphQL.Sample.Models;

namespace GraphQL.Sample.Repositories;

public class UserRepository
{
    private readonly IList<User> _users;

    public UserRepository()
    {
        var faker = new Faker();
        _users = Enumerable.Repeat(0, 20)
            .Select((_, index) => new User
            {
                Id = index + 1,
                Name = faker.Person.FullName,
                Email = faker.Person.Email,
                Phone = faker.Person.Phone,
                Address = faker.Address.FullAddress(),
                Avatar = faker.Person.Avatar,
                Website = faker.Person.Website,
                DateOfBirth = faker.Person.DateOfBirth
            })
            .ToList();
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    /// <summary>
    ///  Get user by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public User? Get(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<User> GetFriends(int id)
    {
        return _users.Where(x => x.Id != id).Where(x => x.Id % id == 0);
    }
    
    public Role GetRole(int id)
    {
        if (id % 5 == 0)
        {
            return new Role
            {
                Id = 1,
                Name = "Admin"
            };
        }
        
        return new Role
        {
            Id = 2,
            Name = "User"
        };
    }
}
