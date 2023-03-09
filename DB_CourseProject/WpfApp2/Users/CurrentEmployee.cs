using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Users
{
    public class CurrentEmployee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string secondname { get; set; }
        public string login { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string post { get; set; }

        public CurrentEmployee()
        {

        }

        public CurrentEmployee(string log,string surn, string name, string secname, string post)
        {
            this.login = log;
            this.surname = surn;
            this.name = name;
            this.secondname = secname;
            this.post = post;
        }

    }
}
