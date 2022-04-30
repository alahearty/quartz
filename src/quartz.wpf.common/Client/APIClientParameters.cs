using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client
{
    public class APIClientParameters
    {
        public APIQuery Query;
        public string BaseUri = null;
        public IEnumerable<APIHeaders> Headers = null;

        public APIClientParameters(APIQuery aPIQuery, string Baseuri=null, IEnumerable<APIHeaders> Headers = null)
        {
            Query = aPIQuery;
            this.Headers = Headers;
            BaseUri = Baseuri;
        }
    }

    public class APIClientRequestParameters<T> : APIClientParameters
    {
        public IRequest<T> Request_data_serializer;

        public APIClientRequestParameters(APIQuery aPIQuery, IRequest<T> request, string Baseuri = null, IEnumerable<APIHeaders> Headers = null): base(aPIQuery, Baseuri, Headers)
        {
            Request_data_serializer = request;
        }
    }
}
