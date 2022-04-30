using quartz.wpf.common.AuthModel;
using quartz.wpf.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.reservoirs.test.mocking
{
    class AuthenticationServiceTest : IAuthenticationService
    {
        private User _user;
        private readonly bool _is_authenticated;
        private string _bearer_token;

        public User User => _user;

        public bool IsAuthenticated => _is_authenticated;

        public string BearerToken => _bearer_token;

        public AuthenticationServiceTest()
        {
            _user = new User
            {
                Email = "someone@gmail.com",
                Firstname = "John",
                Lastname = "Dell",
                Username = "john.dell"
            };
        }

        public bool? Login()
        {
            _bearer_token = "";
            return true;
        }

        public void Logout()
        {
            _bearer_token = null;
            _user = null;
        }

        public void Register()
        {
            _bearer_token = "";
            _user = new User
            {
                Email = "someone@gmail.com",
                Firstname = "John",
                Lastname = "Dell",
                Username = "john.dell"
            };
        }
    }
}
