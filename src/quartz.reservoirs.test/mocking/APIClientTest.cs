using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.reservoirs.test.mocking
{
    public class APIClientTest : IAPIClient
    {
        public IResponsesEnvelope<T> Delete<T>(APIQuery query, string BaseUri = null, IEnumerable<APIHeaders> headers = null)
        {
            return new ReponseEnvelop<T>(null, null, default(T)); ;
        }

        public IResponsesEnvelope<T> Get<T>(APIQuery query, string BaseUri = null, IEnumerable<APIHeaders> headers = null) where T : new()
        {
            return new ReponseEnvelop<T>(null, null, default(T)); ;
        }

        public IResponsesEnvelope<T> Get<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null) where T : new()
        {
            return new ReponseEnvelop<T>(null, null, default(T)); ;
        }

        public IResponsesEnvelope<T> Patch<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null)
        {
            return new ReponseEnvelop<T>(null, null, default(T)); ;
        }

        public IResponsesEnvelope<T> Post<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null) where T : new()
        {
            return new ReponseEnvelop<T>(null, null, default(T)); ;
        }

        public IResponsesEnvelope<T> Put<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null)
        {
            return new ReponseEnvelop<T>(null, null, default(T)); ;
        }
    }
}
