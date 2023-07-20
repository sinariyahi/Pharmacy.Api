using Contracts;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DBHelper
{
    public interface IConnectionUtility
    {
        SqlConnection NewConnection();
    }
    public class ConnectionUtility : IConnectionUtility
    {
        private readonly Configs configs;
        public ConnectionUtility(IOptions<Configs> options)
        {
            this.configs = options.Value;
        }
        public SqlConnection NewConnection()
        {
            return new SqlConnection(configs.MainConnectionString);
        }
    }
}
