// See https://aka.ms/new-console-template for more information
using ConsoleApp2;


//var juniorEmployee = new Employee("junior@dot.com", new string[] { "junior" });
//var seniorEmployee = new Employee("senior@dot.com", new string[] { "senior" });
//var teamLeadEmployee = new Employee("teamLead@dot.com", new string[] { "teamLead", "Admin" });

//juniorEmployee.SetManager(seniorEmployee);
//seniorEmployee.SetManager(teamLeadEmployee);

//juniorEmployee.RequestTimeOff(new TimeOffRequest());

var requestHandler = new RequestCompositeHandler();

requestHandler.Handle(new Request(980));
Console.ReadLine();
