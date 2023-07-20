using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Configs
    {
        public string MainConnectionString { get; set; }
        public string RedisConnection { get; set; }

        public string TokenKey { get; set; }
        public int TokenTimeout { get; set; }
        public string UploadPath { get; set; }
    }
}
