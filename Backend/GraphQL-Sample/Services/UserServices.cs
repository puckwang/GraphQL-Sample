using Bogus;
using GraphQL.Sample.Models;

namespace GraphQL.Sample.Services;

public class UserServices
{
    private readonly IList<User> _users;

    public UserServices()
    {
        var faker = new Faker();
        _users = Enumerable.Repeat(0, 20)
            .Select((_, index) => new User
            {
                Id = index + 1,
                Name = faker.Name.FullName(),
                Email = faker.Internet.Email(),
                Phone = faker.Phone.PhoneNumber(),
                Company = new Company
                {
                    Id = faker.Random.Number(0, 20),
                    Name = faker.Company.CompanyName(),
                    Phone = faker.Phone.PhoneNumber(),
                },
            })
            .ToList();
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    /// <returns></returns>
    public IList<User> GetAll()
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
}
