using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : ICreateUserCommand
    {
        private readonly IDatabaseService _database;
        public CreateUserCommand(
            IDatabaseService database)
        {
            _database = database;
            
        }
        public void Execute(CreateUserModel model) 
        {
            throw new NotImplementedException();
        }
    }
}
