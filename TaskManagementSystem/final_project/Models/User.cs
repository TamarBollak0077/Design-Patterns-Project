using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class User:ISendable
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Role Role { get; set; }
        public Message? MessageDestination { get; set; }
        public bool IsAvailable { get; set; }
        public void Send(string message,User u)
        {
            MessageDestination?.Send(message,u);
        }

    }
}
