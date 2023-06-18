namespace License.viewer.api.Models;

public interface IUserRepository
{
    Task Save(User user);

    Task<List<User>> Search(string? name = null, string? email = null, string? role = null);
}
