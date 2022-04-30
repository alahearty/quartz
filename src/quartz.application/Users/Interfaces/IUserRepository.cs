using Quartz.Application.Interfaces;
using Quartz.Domain.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.Users.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        IQuartzTransaction Transaction { get; }
    }
}
