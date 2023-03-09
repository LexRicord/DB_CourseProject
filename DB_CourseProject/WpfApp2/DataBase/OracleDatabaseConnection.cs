using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.DataBase
{
    public static class OracleDatabaseConnection
    {
        public static string adminConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                         "(HOST=169.254.222.194)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=pdb1)))" +
                                         ";User Id=GAE_1;Password=12345;";
        public static string employeeConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                         "(HOST=169.254.222.194)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=pdb1)))" +
                                         ";User Id=employee;Password=emppass;";
        public static string clientConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                            "(HOST=169.254.222.194)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=pdb1)))" +
                                            ";User Id=client;Password=clipass;";
    }
}
