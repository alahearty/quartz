using quartz.application.Users.QueryInteractors.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.Users.Interfaces
{
    public interface IUserQueries
    {
        UserLoginDto GetUser(string username, string password);
    }
}
