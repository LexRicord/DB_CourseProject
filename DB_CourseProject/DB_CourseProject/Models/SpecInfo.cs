using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class SpecInfo
    {
        public string TypeName { get; set; }
        public string NumOfMasters { get; set; }
        public string NumOfServices { get; set; }
        public string NumOfCompOrders { get; set; }
        public string Income { get; set; }


        public SpecInfo(string type, string numofm, string numofs, string numofcomp, string inc)
        {
            TypeName = type;
            NumOfMasters = numofm;
            NumOfServices = numofs;
            NumOfCompOrders = numofcomp;
            Income = inc;
        }
    }
}
