using quartz.wpf.common.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.reservoirs
{
    public class DeleteReservoirRequest : IRequest<DeleteReservoirResponse>
    {
        public object GetRequestData()
        {
            return this;
        }
        
    }
}
