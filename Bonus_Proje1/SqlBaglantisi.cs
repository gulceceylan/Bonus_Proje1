using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Bonus_Proje1
{
    internal class SqlBaglantisi
    {
     
        public string localhost = "LAPTOP-KUCNJLV5\\SQLEXPRESS;";
        public string db = "Okul;";
        public string dbConnection;
        public SqlConnection baglan;
        public SqlBaglantisi()
        {
            dbConnection = "Data Source=" + localhost + "Initial Catalog=" + db + "Integrated Security=True;";
            baglan = new SqlConnection(dbConnection);   
            baglan.Open();
           
        }
    }
}
