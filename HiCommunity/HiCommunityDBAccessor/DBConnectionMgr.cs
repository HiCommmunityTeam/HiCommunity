using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace HiCommunityDBAccessor
{
    public class DBConnectionMgr
    {
        public static string HiCommunityConnectionString = string.Empty;

        public static MySqlConnection GetHiCommunityConnection()
        {
            MySqlConnection mysqlConn = new MySqlConnection(HiCommunityConnectionString);
            mysqlConn.Open();
            return mysqlConn;
        }

    }
}
