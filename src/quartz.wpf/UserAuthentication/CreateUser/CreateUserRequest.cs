using quartz.wpf.common.AuthModel;
using quartz.wpf.common.Client;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.UserAuthentication.CreateUser
{
    public class CreateUserRequest : IRequest<User>
    {
        private readonly dynamic user;
        private readonly string password;

        public CreateUserRequest(User user, string password)
        {
            this.user = new ExpandoObject();
            Map_user_to_expando(user, password);
        }

        private void Map_user_to_expando(User real_user, string password)
        {
            var dictionary = (IDictionary<string, object>)user;
            foreach (var property in real_user.GetType().GetProperties())
                dictionary.Add(property.Name.ToLower(), property.GetValue(real_user));

            dictionary.Add("password", password);
        }

        public object GetRequestData()
        {
            return user;
        }
    }
}
