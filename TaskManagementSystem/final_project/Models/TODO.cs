using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class TODO : IStatus
    {
        private Task _task { get; set; }
        public TODO(Task task) 
        {
            _task = task;
        }
        public void ChangeStatus()
        {
            _task.UpdateStatus(new InProgress(_task));
        }
        public void DoTask()
        {
            Console.WriteLine("New task created successfully.");
        }

    }
}
