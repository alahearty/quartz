using quartz.wpf.common.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Interfaces
{
    public interface IAuthenticationService
    {
        User User { get; }

        bool IsAuthenticated { get; }

        bool? Login();

        void Logout();

        void Register();

        string BearerToken { get; }
    }
}
