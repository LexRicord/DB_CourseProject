    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class CurrentEmployee
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string secondname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string role { get; set; }

        public CurrentEmployee()
        {
        }

        public CurrentEmployee(string email, string surn, string name,
           string secname, string post)
        {
            this.email = email;
            this.surname = surn;
            this.name = name;
            this.secondname = secname;
            this.role = post;
        }

        public CurrentEmployee(int id, string email, string phonenumber, string surn, string name, 
            string secname, string post)
        {
            this.id = id;
            this.email = email;
            this.phone = phonenumber;
            this.surname = surn;
            this.name = name;
            this.secondname = secname;
            this.role = post;
        }
    }
}
