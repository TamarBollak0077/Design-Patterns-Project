using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    internal class Done : IStatus
    {
        private Task _task { get; set; }
        public Done(Task task)
        {
            _task = task;
        }
        public void ChangeStatus()
        {
            throw new NotImplementedException("illegal action!!");
        }
        public void DoTask()
        {
            if (_task.Reporter.Role == Role.QA) 
                Console.WriteLine("The task was done successfully" );
            else Console.WriteLine("Error! Illegal access, only QA can mark the task as done.");
        }
        public override string? ToString()
        {

            return "\"Done\"";
        }
    }
}
