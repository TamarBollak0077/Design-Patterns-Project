using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class ToConsole: Message
    {
        private static ToConsole? instance = null;
        public override void Send(string message,User u)
        {
            base.Send(message, u);
            Console.WriteLine(message);
        }
        public static ToConsole GetInstance()
        {
            if (instance == null)
            {
                return new ToConsole();
            }
            else return instance;
        }
    }
}
