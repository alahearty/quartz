using Quartz.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.Users.QueryInteractors.UserLogin
{
    public class UserLoginDto
    {
        public string Token { get; set; }
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public static UserLoginDto From(User user)
        {
            if (user == null) return null;
            return new UserLoginDto
            {
                Id = user.Id,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Username = user.UserName,
                Email = user.Email
            };
        }
    }
}
