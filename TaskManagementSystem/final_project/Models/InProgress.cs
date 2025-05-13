using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class InProgress : IStatus
    {
        public Task _task { get; set; }
        public InProgress()
        {
            _task = null;
        }
        public InProgress(Task task)
        {
            _task = task;
        }
        public void ChangeStatus()
        {
            _task.UpdateStatus(new CodeReview(_task));
        }
        public void DoTask()
        {
            Console.WriteLine("the task in progress now , the logged time now is "+_task.getLoggedTime());
        }
        public override string? ToString()
        {

            return "\"In Progress\"";
        }
    }
}
