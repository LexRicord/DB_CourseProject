namespace DB_CourseProject.DataBase
{
    public static class OracleDatabaseConnection
    {
        public static string adminConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                         "(HOST=10.208.124.17)(PORT=1521)))(CONNECT_DATA=(SERVICE_NAME=pdb1)))" +
                                         ";User Id=GAE_1;Password=123456;";
        public static string employeeConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                         "(HOST=10.208.124.17)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=pdb1)))" +
                                         ";User Id=employee;Password=emppass;";
        public static string clientConn = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)" +
                                            "(HOST=10.208.124.17)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=pdb1)))" +
                                            ";User Id=client;Password=clipass;";
    }
}
