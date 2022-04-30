using quartz.wpf.common.Client;
using quartz.wpf.common.Client.Helper;
using quartz.wpf.common.Interfaces;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client
{
    public class SuperAuthenticator : IAuthenticator
    {
        public void Authenticate(IRestClient client, IRestRequest request)
        {
            throw new NotImplementedException();
        }
    }
    public class APIClient : IAPIClient
    {
        private readonly IAuthenticationService authenticationService;

        public APIClient(IAuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        private RestClient GetRestClient(string baseUri)
        {
            var client = new RestClient(baseUri ?? APIConstants.BaseUrl);
            if (authenticationService.IsAuthenticated)
                client.Authenticator = new JwtAuthenticator(authenticationService.BearerToken);

            return client;
        }

        private RestRequest _buildAuthenticationRestClient(APIQuery QueryUrl, Method method, DataFormat format, IEnumerable<APIHeaders> headers=null)
        {
            var api_headers = headers ?? new List<APIHeaders>();
            var rest_request = new RestRequest(QueryUrl.QueryUrl, method, format);
            foreach (var item in api_headers)
            {
                rest_request.AddHeader(item.Name, item.Value);
            }
            return rest_request;
        }

        private IResponsesEnvelope<T> PrepResponse<T>(IRestResponse content)
        {
            return new ReponseEnvelop<T>(content.StatusCode.ToString(), content.StatusDescription, content.Content.DeserializeToClass<T>());
        }

        private IResponsesEnvelope<T> ExecuteAction<T>(Func<IRestResponse> action)
        {
            IRestResponse responses = null;
            try
            {
                responses = action();
                return PrepResponse<T>(responses);
            }
            catch (Exception ex)
            {
                if(responses != null)
                    return new ReponseEnvelop<T>(responses.StatusCode.ToString(), responses.Content, default(T));
                return new ReponseEnvelop<T>(null, null, default(T));
            }
        }

        public IResponsesEnvelope<T> Post<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, 
            IEnumerable<APIHeaders> headers = null) where T : new()
        {
            var content = ExecuteAction<T>(() =>
            {
                var rest_request = _buildAuthenticationRestClient(query, Method.POST, DataFormat.Json, headers);
                rest_request.AddJsonBody(@request_data_serializer.GetRequestData());
                var _httpClient = GetRestClient(BaseUri);
                var task = _httpClient.ExecuteTaskAsync(rest_request);
                return task.Result;
            });
            return content;
        }

        public IResponsesEnvelope<T> Get<T>(APIQuery query, string BaseUri = null, 
            IEnumerable <APIHeaders> headers = null) where T: new()
        {
            var content = ExecuteAction<T>(() =>
            {
                var request = _buildAuthenticationRestClient(query, Method.GET, DataFormat.Json, headers);
                var _httpClient = GetRestClient(BaseUri);
                var task = _httpClient.ExecuteTaskAsync(request);
                return task.Result;
            });
            return content;
        }

        public IResponsesEnvelope<T> Get<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, 
            IEnumerable<APIHeaders> headers = null) where T : new() 
        {
            var content = ExecuteAction<T>(() =>
            {
                var request = _buildAuthenticationRestClient(query, Method.GET, DataFormat.Json, headers);
                request.AddObject(request_data_serializer.GetRequestData());
                var _httpClient = GetRestClient(BaseUri);
                var task = _httpClient.ExecuteTaskAsync(request);
                return task.Result;
            });
            return content;
        }

        public IResponsesEnvelope<T> Put<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, 
            IEnumerable<APIHeaders> headers = null)
        {
            var content = ExecuteAction<T>(() =>
            {
                var rest_request = _buildAuthenticationRestClient(query, Method.PUT, DataFormat.Json, headers);
                rest_request.AddJsonBody(@request_data_serializer.GetRequestData());
                var _httpClient = GetRestClient(BaseUri);
                var task = _httpClient.ExecuteTaskAsync(rest_request);
                return task.Result;
            });
            return content;
        }

        public IResponsesEnvelope<T> Patch<T>(APIQuery query, IRequest<T> request_data_serializer, string BaseUri = null, 
            IEnumerable<APIHeaders> headers = null)
        {
            var content = ExecuteAction<T>(() =>
            {
                var rest_request = _buildAuthenticationRestClient(query, Method.PATCH, DataFormat.Json, headers);
                rest_request.AddJsonBody(@request_data_serializer.GetRequestData());
                var _httpClient = GetRestClient(BaseUri);
                var task = _httpClient.ExecuteTaskAsync(rest_request);
                return task.Result;
            });
            return content;
        }

        public IResponsesEnvelope<T> Delete<T>(APIQuery query, string BaseUri = null,
            IEnumerable<APIHeaders> headers = null)
        {
            var content = ExecuteAction<T>(() =>
            {
                var rest_request = _buildAuthenticationRestClient(query, Method.DELETE, DataFormat.Json, headers);
                var _httpClient = GetRestClient(BaseUri);
                var task = _httpClient.ExecuteTaskAsync(rest_request);
                return task.Result;
            });
            return content;
        }
    }
}
