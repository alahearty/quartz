using quartz.wpf.common.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.reservoirs
{
    public class ReservoirListRequest : IRequest<List<ReservoirIndexResponse>>
    {
        public object GetRequestData()
        {
            return this;
        }
    }
}
