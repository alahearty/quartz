using FluentNHibernate.Mapping;
using Quartz.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.persistence.nhibernate.Users.Mappings
{
    public class UserMappings : ClassMap<User>
    {
        public UserMappings()
        {
            Table("Users");
            Id(x => x.Id);

            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Email).Unique();
            Map(x => x.Password);
            Map(x => x.UserName).Unique();
        }
    }
}
