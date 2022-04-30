using quartz.wpf.common.Client.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client
{
    public interface IRequest
    {
        object GetRequestData();
    }

    public interface IRequest<out TResponse> : IRequest
    {
        
    }
}
