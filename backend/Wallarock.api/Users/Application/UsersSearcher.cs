namespace License.viewer.api.Users.Application;

using License.viewer.api.Models;

public sealed class UsersSearcher
{
    private readonly IUserRepository _repository;

    public UsersSearcher(IUserRepository repository)
    {
        this._repository = repository;
    }

    public async Task<List<User>> Execute(string requestUser, string requestPassword)
    {
        List<User> users = await this._repository.Search(name: requestUser);
        User? user = users.FirstOrDefault(x => x.Password == requestPassword);
        if (user == null)
        {
            return new List<User>();
        }

        return new List<User> { user };
    }
}
