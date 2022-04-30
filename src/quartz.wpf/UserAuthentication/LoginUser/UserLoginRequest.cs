using quartz.wpf.common.AuthModel;
using quartz.wpf.common.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.UserAuthentication.LoginUser
{
    public class UserLoginRequest : IRequest<User>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public object GetRequestData()
        {
            return this;
        }
    }
}
