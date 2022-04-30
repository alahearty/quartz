using quartz.wpf.common.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.application.reservoirs
{
    public class TodoRequest : IRequest<IEnumerable<TodoReponse>>
    {
        public object GetRequestData()
        {
            return this;
        }
    }
}
