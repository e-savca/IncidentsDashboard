using System.Threading.Tasks;

namespace Application.Users.Commands.UpdateUser
{
    public interface IUpdateUserCommand
    {
        Task<UpdateUserModel> ExecuteAsync(UpdateUserModel model);
    }
}
