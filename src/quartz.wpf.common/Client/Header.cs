using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quartz.wpf.common.Client
{
    public class APIHeaders
    {
        public APIHeaders(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
