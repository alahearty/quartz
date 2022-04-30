using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.Users.QueryInteractors.UserLogin
{
    public class UserLoginRequest : IRequest<UserLoginDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
