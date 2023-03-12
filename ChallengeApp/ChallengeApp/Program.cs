using ChallengeApp;

Console.WriteLine("Witamy w programie XYZ do oceny pracowników");
Console.WriteLine("===========================================");
Console.WriteLine();
var employee = new Employee();
Console.WriteLine("Podaj ocenę pracownika: ");
var input = Console.ReadLine();
employee.AddGrade(input);

while (true)
{
    Console.WriteLine("Podaj kolejną ocenę pracownika:");
    input = Console.ReadLine();
    if (input.ToUpper() == "Q")
    {
        break;
    }
    employee.AddGrade(input);
}


var statistics = employee.GetStatistics();
Console.WriteLine($"Najwyższa ocena: {statistics.Max}");
Console.WriteLine($"Najniższa ocena: {statistics.Min}");
Console.WriteLine($"Średnia ocena: {statistics.Average:N2}");
Console.WriteLine($"Średnia ocena w systemie angielskim: {statistics.AverageLetter}");

