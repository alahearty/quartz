using Newtonsoft.Json;
using quartz.wpf.common.AuthModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.application.reservoirs
{
    public class ReservoirIndexResponse
    {
        [JsonProperty("id")]
        public int ReservoirId { get; set; }

        [JsonProperty("name")]
        public string ReservoirName { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }
        
    }
}
