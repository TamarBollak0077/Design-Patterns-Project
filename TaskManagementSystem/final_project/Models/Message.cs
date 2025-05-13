using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class Message: ISendable
    {
        public virtual void Send(string message, User u)
        {
            Console.WriteLine(u.Role +" "+ u.Name+" got the message: \"" + message+"\"");
        }
    }
}
