using final_project.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using final_project.Interfaces;

namespace final_project.Models
{
    public class TaskBuilder
    {
        DateTime? CreationDate = null;
        string? Title = null;
        string? Description = null;
        User? Assignee = null;
        User? Reporter = null;
        IStatus? Status = null;
        PriorityOptions? Priority = null;
        float EstimationTime = 0;
        float LoggedTime = 0;
        List<TaskActions>? SubTasks = null;

        public TaskBuilder(string title, string description, PriorityOptions priority)
        {
            Title = title;
            Description = description;
            Priority = priority;
        }
        public void createTaskDate()
        {
            CreationDate = DateTime.Now;
        }
        public void findAssignee(User assignee)
        {
            Assignee = assignee;
        }
        public void findReporter(User reporter)
        {
            Reporter = reporter;
        }
        public void BuildSubTasks(TaskActions subTask)
        {
            if (SubTasks == null)
            {
                SubTasks = new List<TaskActions>();
            }
            SubTasks.Add(subTask);
            EstimationTime += subTask.getEstimationTime();
        }
        public void BuildEstimationTime(float hours)
        {
            EstimationTime= hours;
        }
        public Task buildTask()
        {
            if (CreationDate == null || Assignee == null ||
                Reporter == null || EstimationTime == 0)
            {
                throw new Exception("Error! Can't open Task with missing detailes");
            }

            return new Task()
            {
                CreationDate = (DateTime)CreationDate,
                Title = (string)Title,
                Description = (string)Description,
                Assignee = Assignee,
                Reporter = Reporter,
                Status = null,
                Priority = (PriorityOptions)Priority,
                EstimationTime = EstimationTime,
                LoggedTime = LoggedTime,
                SubTasks= SubTasks,
            };
        }
    }
}

