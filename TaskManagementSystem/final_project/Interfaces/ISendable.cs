using final_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Interfaces
{
    public interface ISendable
    {
        void Send(string message, User u);
    }
}
