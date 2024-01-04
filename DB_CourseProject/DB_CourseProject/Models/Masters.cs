using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class Masters
    {
        public string Login { get; set; }
        public string Surname { get; set; }
        public int NumOfCompOrders { get; set; }
        public int NumOfRetOrders { get; set; }
        public string TypeName { get; set; }

        public Masters(string log, string surn, int num, int ret, string type)
        {
            Login = log;
            Surname = surn;
            NumOfCompOrders = num;
            NumOfRetOrders = ret;
            TypeName = type;
        }
    }
}
