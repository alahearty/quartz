using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Interfaces
{
    public interface IResponsesEnvelope<T>
    {
        string Status { get; }
        T Data { get; }
        string Message { get; }

        bool HasData();
    }
}
