using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace force.Repository
{
    public class SqlConfiguration
    {
        public SqlConfiguration(string connection)
        {
            ConnectionString = connection;
        }
        
        public string ConnectionString { get; set; }
    }
}
