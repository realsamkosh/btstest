using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bts.utitlity
{
    public class ResponseModel
    {
        public object data { get; set; }
        public bool success { get; set; }
        public string message { get; set; }
        public int status { get; set; }
    }
}
