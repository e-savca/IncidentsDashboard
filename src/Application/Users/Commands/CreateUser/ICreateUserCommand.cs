using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        Task<CreateUserModel> ExecuteAsync(CreateUserModel model);
    }
}
