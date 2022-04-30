using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client
{
    public class APIQuery
    {
        private APIQuery()
        {
            QueryParameterList = new List<KeyValuePair<string, string>>();
        }

        public static APIQuery Create(string url)
        {
            return new APIQuery
            {
                QueryUrl = url
            };
        }

        public string QueryUrl { get; private set; }
        public List<KeyValuePair<string, string>> QueryParameterList { get; }

        public APIQuery AddQueryParameter(string key, object value)
        {
            AddQueryParameter(key, value?.ToString());
            return this;
        }

        public APIQuery AppendUrl(string path)
        {
            if(path.StartsWith("/"))
                QueryUrl = $"{QueryUrl}{path}";
            else
                QueryUrl = $"{QueryUrl}/{path}";
            return this;
        }

        public APIQuery AddQueryParameter(string key, string value)
        {
            if (QueryParameterList.Count == 0)
            {
                QueryUrl += $"?{key}={value}";
            }
            else
            {
                QueryUrl += $"&{key}={value}";
            }

            // Build key / value paramater list for signing
            QueryParameterList.Add(new KeyValuePair<string, string>(key, value));
            return this;
        }
    }
}
