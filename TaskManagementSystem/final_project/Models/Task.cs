using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using final_project.Enums;
using final_project.Interfaces;

namespace final_project.Models
{
    public class Task : ITime, IStatus
    {
        public DateTime CreationDate { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public User? Assignee { get; set; }
        public User? Reporter { get; set; }
        public IStatus? Status { get; set; }
        public PriorityOptions Priority { get; set; }
        public float EstimationTime { get; set; }
        public float LoggedTime { get; set; }
        public List<TaskActions> SubTasks { get; set; }

        //the action we can do in the task:
        public void ChangeStatus()
        {
            Status.ChangeStatus();
        }
        public void UpdateStatus(IStatus nextStatus)
        {
            Status = nextStatus;
        }
        public void DoTask()
        {
            Status.DoTask();
        }
        public float getEstimationTime()
        {
            if (SubTasks == null)
            {
                return EstimationTime;
            }
            else
            {
                float sum = 0;
                foreach (var task in SubTasks)
                {
                    sum += task.getEstimationTime();
                }
                return sum;
            }
        }
        public float getLoggedTime()
        {
            if (SubTasks == null)
            {
                return LoggedTime;
            }
            else
            {
                float sum = 0;
                foreach (var task in SubTasks)
                {
                    sum += task.getLoggedTime();
                }
                return sum;
            }
        }
        public bool updateLoggedTime(float hour)
        {
            if (SubTasks != null) {
                Console.WriteLine("you can't update logged time of a task with subTask");
                return false;
            }
            LoggedTime += hour;
            return true;
        }
        public void AddSubTask(TaskActions task)
        {
            if (SubTasks == null) {
                Console.WriteLine("we sorry, you choose do it alone");
            }
            else SubTasks.Add(task);
        }
        public IMemento CreateBackUp()
        {
            return new Memento(Status, EstimationTime, LoggedTime, SubTasks);
        }
        public void Restore(IMemento memento)
        {
            Status = ((Memento)memento).Status;
            EstimationTime = ((Memento)memento).EstimationTime;
            LoggedTime = ((Memento)memento).LoggedTime;
            SubTasks = ((Memento)memento).SubTasks;
        }
        private class Memento : IMemento
        {
            public IStatus Status { get; set; }
            public float EstimationTime { get; set; }
            public float LoggedTime { get; set; }
            public List<TaskActions> SubTasks { get; set; }
            public Memento(IStatus status, float estimationTime, float loggedTime, List<TaskActions> subTusks)
            {
                Status = status;
                EstimationTime = estimationTime;
                LoggedTime = loggedTime;
                SubTasks = subTusks;
            }
        }

    }
}

