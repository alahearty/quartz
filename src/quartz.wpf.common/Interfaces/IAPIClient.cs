using System.Collections.Generic;
using quartz.wpf.common.Client;
using quartz.wpf.common.Interfaces;

namespace quartz.wpf.common.Interfaces
{
    public interface IAPIClient
    {
        IResponsesEnvelope<T> Delete<T>(APIQuery query, string BaseUri = null, IEnumerable<APIHeaders> headers = null);
        IResponsesEnvelope<T> Get<T>(APIQuery query, string BaseUri = null, IEnumerable<APIHeaders> headers = null) where T : new();
        IResponsesEnvelope<T> Get<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null) where T : new();
        IResponsesEnvelope<T> Patch<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null);
        IResponsesEnvelope<T> Post<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null) where T : new();
        IResponsesEnvelope<T> Put<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, IEnumerable<APIHeaders> headers = null);
    }
}