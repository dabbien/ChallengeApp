﻿using ChallengeApp;

var employee = new Employee("Bogdan", "Bogdanowski");
employee.AddGrade(2);
employee.AddGrade(3);
employee.AddGrade(4);
var statistics = employee.GetStatistics();
Console.WriteLine($"Average: {statistics.Average:N2}");
Console.WriteLine($"Max: {statistics.Max}");
Console.WriteLine($"Min: {statistics.Min}");

SetSth(out statistics);

void SetSth(out Statistics statistics)
{
    statistics = new Statistics();
}
