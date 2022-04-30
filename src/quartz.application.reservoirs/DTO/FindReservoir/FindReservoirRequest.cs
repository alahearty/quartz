using quartz.wpf.common.Client;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.reservoirs
{
    public class FindReservoirRequest: IRequest<Reservoir>
    {
        public int id { get; set; }
        public FindReservoirRequest(int id)
        {
            this.id = id;
        }

        public object GetRequestData()
        {
            return this;
        }
    }
}
