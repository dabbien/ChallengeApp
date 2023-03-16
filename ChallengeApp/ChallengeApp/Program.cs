using ChallengeApp;

Console.WriteLine("Witamy w programie XYZ do oceny pracowników");
Console.WriteLine("===========================================");
Console.WriteLine();
var employee = new Employee("Zenon", "Zenonowicz", "Handlowiec");

Console.WriteLine("Podaj ocenę pracownika: ");
var input = Console.ReadLine();
try
{
    employee.AddGrade(input);
}
catch (Exception err)
{
    Console.WriteLine($"Exception catched: {err.Message}");
}

while (true)
{
    Console.WriteLine("Podaj kolejną ocenę pracownika:");
    input = Console.ReadLine();
    if (input.ToUpper() == "Q")
    {
        break;
    }
    try
    {
        employee.AddGrade(input);
    }
    catch (Exception err)
    {
        Console.WriteLine($"Exception catched: {err.Message}");
    }
}


var statistics = employee.GetStatistics();
Console.WriteLine($"Najwyższa ocena: {statistics.Max}");
Console.WriteLine($"Najniższa ocena: {statistics.Min}");
Console.WriteLine($"Średnia ocena: {statistics.Average:N2}");
Console.WriteLine($"Średnia ocena w systemie angielskim: {statistics.AverageLetter}");

