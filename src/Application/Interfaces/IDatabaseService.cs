using Domain.Users;
using System.Data.Entity;
namespace Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<User> Users { get; set; }

        void Save();
    }
}
