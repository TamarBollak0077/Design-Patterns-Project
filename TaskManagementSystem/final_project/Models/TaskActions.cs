using final_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public class TaskActions
    {
        private Task Task { get; set; }
        Stack<IMemento> History { get; set; }
        public TaskActions(Task task)
        {
            Task = task;
            History = new Stack<IMemento>();
        }
        public void Undo()
        {
            Task.Restore(History.Pop());
        }

        // update the history when the task is changed:

        public void ChangeStatus()
        {
            History.Push(Task.CreateBackUp());
            if (Task.SubTasks != null)
                foreach (var subTask in Task.SubTasks)
                {
                    subTask.ChangeStatus();
                }
            Task.ChangeStatus();
            Task.Assignee.Send("the status is changed to " + Task.Status.ToString(), Task.Assignee);
            Task.Reporter.Send("the status is changed to " + Task.Status.ToString(), Task.Reporter);
        }
        public void updateLoggedTime(float hour)
        {
            History.Push(Task.CreateBackUp());
            bool isUpdated=Task.updateLoggedTime(hour);
            if (isUpdated)
            {
                Task.Assignee.Send("the logged Time is updated.", Task.Assignee);
                Task.Reporter.Send("the logged Time is updated.", Task.Reporter);
            }

        }
        public void AddSubTask(TaskActions task)
        {
            if (Task.Status.ToString() != "\"In Progress\"") {
                throw new Exception("ERROR!! you can add a subtask only in progress");
            }
            History.Push(Task.CreateBackUp());
            Task.AddSubTask(task);
            Task.Assignee.Send("the task devided to one more sub task.", Task.Assignee);
            Task.Reporter.Send("the task devided to one more sub task.", Task.Reporter);
        }
        public void UpdateSubTask(string subTaskDescription, string func, float hour = 0, TaskActions task = null)
        {
            History.Push(Task.CreateBackUp());
            foreach (var subTask in Task.SubTasks)
            {
                if (subTaskDescription == subTask.GetSubTaskDescription())
                {
                    switch (func)
                    {
                        case "getEstimationTime":
                            {
                                Console.WriteLine("the subtask estimation time is " + subTask.getEstimationTime());
                                break;
                            }
                        case "getLoggedTime":
                            {
                                Console.WriteLine("the subtask logged time is "+subTask.getLoggedTime());
                                break;
                            }
                        case "updateLoggedTime":
                            {
                                subTask.updateLoggedTime(hour);
                                break;
                            }
                        case "AddSubTask":
                            {
                                subTask.AddSubTask(task);
                                break;
                            }
                        default:
                            Console.WriteLine("(\"illegal action!!\");");
                            break;
                    }
                }
            }
        }
        
        //Functions that do not change history:

        public float getEstimationTime()
        {
            return Task.getEstimationTime();
        }
        public float getLoggedTime()
        {
            return Task.getLoggedTime();
        }
        public void DoTask()
        {
            Task.DoTask();
        }
        public string GetSubTaskTitle()
        {
            return Task.Title;
        }
        public string GetSubTaskDescription()
        {
            return Task.Description;
        }
    }
}
