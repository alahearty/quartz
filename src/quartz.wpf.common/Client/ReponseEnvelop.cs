using quartz.wpf.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client
{
    public class ReponseEnvelop<T> : IResponsesEnvelope<T>
    {
        private readonly string _status;
        private readonly T _data;
        private readonly string _message;

        public string Status => _status;

        public T Data => _data;

        public string Message => _message;

        public bool HasData()
        {
            return Data != null;
        }
        public ReponseEnvelop(string status, string message, T data)
        {
            this._status = status;
            this._data = data;
            this._message = message;
        }
    }
}
