using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Employee
{
    public class Info
    {
        public int Order_id { get; set; }
        public string Phonenumber { get; set; }
        public string Login { get; set; }
        public int Price { get; set; }
        public string Service { get; set; }
        public string Date { get; set; }
        public string Model { get; set; }
        public int E_id { get; set; }
        public string enddate { get; set; }

        public Info(int order, string name, int price, string service)
        {
            Order_id = order;
            Phonenumber = name;
            Price = price;
            Service = service;
        }

        public Info(int order, string name, int price, string service, string prod, string model, string endd, string l)
        {
            Order_id = order;
            Phonenumber = name;
            Login = l;
            Price = price;
            Service = service;
            Date = prod;
            Model = model;
            enddate = endd;
        }

    }
}
