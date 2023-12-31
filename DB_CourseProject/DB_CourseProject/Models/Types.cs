using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class Types
    {
        public string Name { get; set; }
        public string NumOfCompOrders { get; set; }
        public string NumOfMasters { get; set; }


        public Types(string name, string numofcomp, string numofm)
        {
            Name = name;
            NumOfMasters = numofm;
            NumOfCompOrders = numofcomp;
        }
    }
}
