using final_project.Enums;
using final_project.Interfaces;
using final_project.Models;
using Task = final_project.Models.Task;

public class Program
{

    //a generic function to create a new task
    public static TaskActions CreateTask(string title, string description, PriorityOptions priority, InProgress status=null)
    {
        //basic task creation
        TaskBuilder taskBuilder = new TaskBuilder(title, description, priority);

        User? manager = new User();
        User? worker = new User();

        do//add asignee
        {
            Console.WriteLine("insert manager name:");
            var name = Console.ReadLine();
            manager = Employees.GetEmployees().FirstOrDefault(e => e.Name == name);
            if (manager == null)
                Console.WriteLine("Erorr! can't find this manager, insert again.");
            else if (manager.Role != Role.Manager )
                Console.WriteLine("Erorr! this employee isn't manager, please insert a manager name.");

        } while (manager == null || manager.Role != Role.Manager);

        taskBuilder.findAssignee(manager);
        manager.IsAvailable = false;

        do// add reporter
        {
            Console.WriteLine("insert worker name:");
            var name = Console.ReadLine();
            worker = Employees.GetEmployees().FirstOrDefault(e => e.Name == name);
            if (worker == null)
                Console.WriteLine("Erorr! can't find this manager, insert again.");

        } while (worker == null);
        worker.IsAvailable = false;

        taskBuilder.findReporter(worker);


        //add first subtask:
        Console.WriteLine("Would you like to divide the tasks into subtasks?");//add subtasks
        var choice = Console.ReadLine();
        switch (choice)
        {
            case "yes":
                taskBuilder.BuildSubTasks(CreateTask("Task Management System", "allows users to assign tasks.", PriorityOptions.Low));
                break;
            case "no":
                Console.WriteLine("please insert estimation time for this task");
                float number = float.Parse(Console.ReadLine());
                taskBuilder.BuildEstimationTime(number);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        //add creation date
        taskBuilder.createTaskDate();

        //create the completed new task
        Task task = taskBuilder.buildTask();

        //add curr status
        if (status == null)
            task.Status = new TODO(task);
        else {
            task.Status = status;
            status._task = task;
        } 

        //return object with the optional actions without an access to the task properties.
        var optionalActions = new TaskActions(task);
        return optionalActions;
    }
    public static void Main()
    {
        //create task step by step:
        var task1 = CreateTask("Task Management System", "allows users to create, assign, and track tasks.", PriorityOptions.High);

        //task workFlow

        //TODO
        task1.DoTask();
        task1.ChangeStatus();

        //In Progress...
        Console.WriteLine("Estimation time: "+task1.getEstimationTime());
        Console.WriteLine("Logged time: " + task1.getLoggedTime());
        task1.AddSubTask(CreateTask(task1.GetSubTaskTitle(), "allows users to update tasks.",PriorityOptions.High,new InProgress()));

        task1.updateLoggedTime(4);
        task1.updateLoggedTime(3);
        task1.updateLoggedTime(5);

        task1.UpdateSubTask("allows users to assign tasks.", "updateLoggedTime",4);
        task1.UpdateSubTask("allows users to assign tasks.", "getLoggedTime"); 
        task1.UpdateSubTask("allows users to update tasks.", "updateLoggedTime", 3);

        task1.getLoggedTime();
        task1.DoTask();
        task1.ChangeStatus();

        //Code Review
        task1.DoTask();
        task1.ChangeStatus();

        //QA
        task1.DoTask();
        task1.ChangeStatus();

        //Done
        task1.DoTask();

        //throw exception
        //task1.ChangeStatus();

        //Restore
        task1.Undo();
    }


}

