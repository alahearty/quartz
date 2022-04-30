using quartz.wpf.common.Client;
using quartz.wpf.domain.Models.Reservoirs;
using System;
using System.Collections.Generic;
using System.Text;

namespace quartz.application.reservoirs
{
    public class CreateReservoirRequest : IRequest<int>
    {
        private Reservoir _reservoir;

        public CreateReservoirRequest(Reservoir reservoir)
        {
            this._reservoir = reservoir;
        }

        public object GetRequestData()
        {
            return this._reservoir;
        }
    }
}
