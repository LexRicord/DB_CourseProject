using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_CourseProject.Models
{
    public class CurrentClient
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
        public string Role { get; set; }

        public CurrentClient()
        {
        }

        public CurrentClient(int id, string phone, string email, double balance, string role)
        {
            this.Id = id;
            this.PhoneNumber = phone;
            this.Email = email;
            this.Balance = balance;
            this.Role = role;
        }
    }
    
}
