using quartz.application.Users.Interfaces;
using quartz.application.Users.QueryInteractors.UserLogin;
using Quartz.Domain.Users;
using Quartz.Persistence.Nhibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace quartz.persistence.nhibernate.Users
{
    public class UserQueries : IUserQueries
    {
        private readonly INhibernateTransaction _nhibernateTransaction;

        public UserQueries(INhibernateTransaction nhibernateTransaction)
        {
            _nhibernateTransaction = nhibernateTransaction;
        }

        public UserLoginDto GetUser(string username, string password)
        {
            var user = _nhibernateTransaction.Session.Query<User>().Where(u => u.UserName == username).SingleOrDefault();
            return UserLoginDto.From(user);
        }
    }
}
