using MediatR;
using System.Collections;
using System.Collections.Generic;

namespace Quartz.Application.Reservoirs.QueryInteractors
{
    public class GetAllReservoirListRequest: IRequest<IEnumerable<ReservoirListDto>>
    {
    }
}
