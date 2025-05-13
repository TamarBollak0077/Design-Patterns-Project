using final_project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project.Models
{
    public static class Employees
    {
        private static List<User> employees = new List<User>
    {
        new User {  Name = "Nachum", Email="Nachum@office.org.il",Role=Role.Developer,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Yossi", Email="Yossi@office.org.il",Role=Role.QA,MessageDestination=ToConsole.GetInstance(),IsAvailable = true },
        new User { Name = "Benni", Email="Benni@office.org.il",Role=Role.Manager,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Tzachi", Email="Tzachi@office.org.il",Role=Role.Manager,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Achmed", Email="Achmed@office.org.il",Role=Role.QA,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Galit", Email="Galit@office.org.il",Role=Role.Developer,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Idit", Email="Idit@office.org.il",Role=Role.Developer,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Miri", Email="Miri@office.org.il",Role=Role.Manager,MessageDestination=ToConsole.GetInstance(),IsAvailable=true },
        new User { Name = "Tamar", Email="Tamar@office.org.il",Role=Role.Manager,MessageDestination=ToConsole.GetInstance(),IsAvailable=true }
};
        public static List<User> GetEmployees()
        {
            return employees;
        }
    }
}
