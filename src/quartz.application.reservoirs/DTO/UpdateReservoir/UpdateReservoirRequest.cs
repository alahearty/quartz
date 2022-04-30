using quartz.wpf.common.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.reservoirs
{
    public class UpdateReservoirRequest: IRequest<UpdateReservoirResponse>
    {
        public object GetRequestData()
        {
            return this;
        }
        
    }
}
