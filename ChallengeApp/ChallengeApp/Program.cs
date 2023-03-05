using ChallengeApp;

Employee dude1 = new Employee("Xavier", "Xavierski", 22, "M");
Employee dude2 = new Employee("Irena", "Irenowska", 33, "F");
Employee dude3 = new Employee("Elżbieta", "Elżbietowska", 44, "F");

List<Employee> dudes = new List<Employee>();

dudes.Add(dude1);
dudes.Add(dude2);
dudes.Add(dude3);

dude1.Reward(10);
dude1.Reward(6);
dude1.Reward(2);
dude1.Reward(8);
dude1.Reward(7);

dude2.Reward(10);
dude2.Reward(6);
dude2.Reward(2);
dude2.Reward(8);
dude2.Reward(7);

dude3.Reward(10);
dude3.Reward(6);
dude3.Reward(2);
dude3.Reward(8);
dude3.Reward(7);

dudes = dudes.OrderByDescending(o => o.TotalScore).ToList();

var i = 0;
var winners = "";

while (dudes[i].TotalScore == (i + 1 < dudes.Count ? dudes[i + 1].TotalScore : dudes[i].TotalScore + 1))
{
    i++;
}

for (int j = 0; j <= i; j++)
{
    if (j == 0)
    {
        winners += $"{dudes[0].Title} {dudes[0].Name} {dudes[0].Surname}";
    }
    else if (j == i)
    {
        winners += $" and {dudes[j].Title} {dudes[j].Name} {dudes[j].Surname}";
    }
    else
    {
        winners += $", {dudes[j].Title} {dudes[j].Name} {dudes[j].Surname}";
    }
}

if (i == 0)
{
    Console.WriteLine($"The employee of the week is {winners}, which scored {dudes[0].TotalScore} points in total. Congratulations!");
}
else
{
    Console.WriteLine($"Employees of the week are: {winners}. Each of them scored {dudes[0].TotalScore} points in total. Congratulations!");
}



