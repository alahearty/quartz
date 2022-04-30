using System;
using System.Collections.Generic;
using System.Text;
using quartz.application.Users.QueryInteractors.UserLogin;

namespace quartz.application.Users.Interfaces
{
    public interface IAuthenticationService
    {
        void Authenticate(UserLoginDto user);
    }
}
