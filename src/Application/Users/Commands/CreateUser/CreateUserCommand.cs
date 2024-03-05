using Application.Interfaces;
using System;

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
