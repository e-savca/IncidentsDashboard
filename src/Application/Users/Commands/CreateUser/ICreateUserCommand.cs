﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Commands.CreateUser
{
    public interface ICreateUserCommand
    {
        void Execute(CreateUserModel model);
    }
}
