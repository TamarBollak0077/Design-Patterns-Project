using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class CodeReview : IStatus
    {
        private Task _task { get; set; }
        public CodeReview(Task task)
        {
            _task = task;
        }
        public void ChangeStatus()
        {
            _task.UpdateStatus(new QA(_task));
        }
        public void DoTask()
        {
            if (_task.Reporter.Role != Role.Manager)
            {
                _task.Reporter.IsAvailable= true;   
                foreach (var employee in Employees.GetEmployees())
                {
                    if(employee.Role==Role.Manager && employee.IsAvailable)
                    {
                        _task.Reporter = employee;
                        _task.Reporter.IsAvailable = false;
                        Console.WriteLine("The task was transferred to manager "+ employee.Name+ ".");
                        break;
                    }
                }
            }
            if(_task.Reporter.Role == Role.Manager)
            {
                Console.WriteLine("The task in code review now");
            }
            else throw new Exception("Erorr! there is no available manager to code review.");
        }
        public override string? ToString()
        {

            return "\"Code Review\"";
        }
    }
}
