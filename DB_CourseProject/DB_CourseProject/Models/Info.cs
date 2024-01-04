using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class Info
    {
        public int Order_id { get; set; }
        public string ClientEmail { get; set; }
        public int OrderPrice { get; set; }
        public string ServicePackOrder { get; set; }
        public string OrderRegDate { get; set; }
        public string OrderEndDate { get; set; }
        public string OrderState { get; set; }
        public string OrderDescription { get; set; }
        public string Model { get; set; }
        public int E_id { get; set; }


    public Info(int order, string clientEmail, int price, string spackorder)
        {
            Order_id = order;
            ClientEmail = clientEmail;
            OrderPrice = price;
            ServicePackOrder = spackorder;
        }

        public Info(int order)
        {
            Order_id = order;
        }

        public Info(int order_id, string clientEmail, int price, string spackorder, string orderRegDate, 
            string orderEndDate, string orderState, string desc, string model, int emp_id)
        {
            Order_id = order_id;
            ClientEmail = clientEmail;
            OrderPrice = price;
            ServicePackOrder = spackorder;
            OrderRegDate = orderRegDate;
            OrderEndDate = orderEndDate;
            OrderState = orderState;
            OrderDescription = desc;
            Model = model;
            E_id = emp_id;
        }
        public Info(int order_id, string clientEmail, int price, string spackorder, string orderRegDate,
            string orderEndDate, string orderState, string desc, string model)
        {
            Order_id = order_id;
            ClientEmail = clientEmail;
            OrderPrice = price;
            ServicePackOrder = spackorder;
            OrderRegDate = orderRegDate;
            OrderEndDate = orderEndDate;
            OrderState = orderState;
            OrderDescription = desc;
            Model = model;
        }
        public Info(int order_id, int price, string spackorder, string orderRegDate,
            string orderEndDate, string orderState, string desc, string model, int emp_id)
        {
            Order_id = order_id;
            OrderPrice = price;
            ServicePackOrder = spackorder;
            OrderRegDate = orderRegDate;
            OrderEndDate = orderEndDate;
            OrderState = orderState;
            OrderDescription = desc;
            Model = model;
            E_id = emp_id;
        }
    }
}
