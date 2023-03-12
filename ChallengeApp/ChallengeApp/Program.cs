using ChallengeApp;

var employee = new Employee("Bogdan", "Bogdanowski");
employee.AddGrade(200);
employee.AddGrade(3);
employee.AddGrade(4);
var statistics1 = employee.GetStatisticsWithForeach();
var statistics2 = employee.GetStatisticsWithFor();
var statistics3 = employee.GetStatisticsWithWhile();
var statistics4 = employee.GetStatisticsWithDoWhile();
Console.WriteLine($"Average-foreach: {statistics1.Average:N2}");
Console.WriteLine($"Average-for: {statistics2.Average:N2}");
Console.WriteLine($"Average-while: {statistics3.Average:N2}");
Console.WriteLine($"Average-doWhile: {statistics4.Average:N2}");


