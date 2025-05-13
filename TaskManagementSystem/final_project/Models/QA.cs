using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class QA : IStatus
    {
        private Task _task { get; set; }
        public QA(Task task)
        {
            _task = task;
        }
        public void ChangeStatus()
        {
            _task.UpdateStatus(new Done(_task));
        }
        public void DoTask()
        {
            if (_task.Reporter.Role != Role.QA)
            {
                _task.Reporter.IsAvailable = true;
                foreach (var employee in Employees.GetEmployees())
                {
                    if (employee.Role == Role.QA && employee.IsAvailable)
                    {
                        _task.Reporter = employee;
                        _task.Reporter.IsAvailable = false;
                        Console.WriteLine("The task was transferred to QA");
                        break;
                    }
                }
            }
            if (_task.Reporter.Role == Role.QA)
            {
                Console.WriteLine("The task in QA now");
            }
            else Console.WriteLine("Erorr! there is no available QA.");

        }
        public override string? ToString()
        {

            return "\"QA\"";
        }
    }
}
