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
        public string NumOfCompOrders { get; set; }
        public string NumOfRetOrders { get; set; }
        public string TypeName { get; set; }

        public Masters(string log, string surn, string num, string ret, string type)
        {
            Login = log;
            Surname = surn;
            NumOfCompOrders = num;
            NumOfRetOrders = ret;
            TypeName = type;
        }
    }
}
