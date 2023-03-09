using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.DataBase
{
    public class Services
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string CompTime { get; set; }
        public string TypeName { get; set; }

        public Services(string name, string price, string time,string type)
        {
            Name = name;
            Price = price;
            CompTime = time;
            TypeName = type;
        }
    }
    public class Serv
    {
        public string Name { get; set; }
        public string Price { get; set; }

        public Serv(string name, string price)
        {
            Name = name;
            Price = price;
        }
    }
    public class Types
    {
        public string Name { get; set; }
        public string Income { get; set; }
        public string NumOfCompOrders { get; set; }
        public string NumOfMasters { get; set; }


        public Types(string name, string inc, string numofcomp, string numofm)
        {
            Name = name;
            NumOfMasters = numofm;
            NumOfCompOrders = numofcomp;
            Income = inc;
        }
    }
    public class Masters
    {
        public string Login { get; set; }
        public string Surname { get; set; }
        public string NumOfCompOrders { get; set; }
        public string Income { get; set; }
        public string TypeName { get; set; }

        public Masters(string log, string surn, string num, string inc, string type)
        {
            Login = log;
            Surname = surn;
            NumOfCompOrders = num;
            Income = inc;
            TypeName = type;
        }
    }
    public class SpecInfo
    {
        public string TypeName { get; set; }
        public string NumOfMasters { get; set; }
        public string NumOfServices { get; set; }
        public string NumOfCompOrders { get; set; }
        public string Income { get; set; }
        

        public SpecInfo(string type, string numofm, string numofs, string numofcomp,string inc)
        {
            TypeName = type;
            NumOfMasters = numofm;
            NumOfServices = numofs;
            NumOfCompOrders = numofcomp;
            Income = inc;
        }
    }
}
