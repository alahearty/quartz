using MediatR;
using quartz.application.Users.QueryInteractors.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.Users.CommandInteractors.CreateUser
{
    public class CreateUserRequest: IRequest<UserLoginDto>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
    
}
