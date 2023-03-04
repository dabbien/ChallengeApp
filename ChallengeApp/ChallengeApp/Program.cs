using ChallengeApp;

Employee dude1 = new Employee("Xavier", "Xavierski", 22, "M");
Employee dude2 = new Employee("Irena", "Irenowska", 33, "F");
Employee dude3 = new Employee("Elżbieta", "Elżbietowska", 44, "F");

List<Employee> dudes = new List<Employee>();
dudes.Add(dude1);
dudes.Add(dude2);
dudes.Add(dude3);

dude1.Reward(10);
dude1.Reward(4);
dude1.Reward(9);
dude1.Reward(2);
dude1.Reward(0);

dude2.Reward(7);
dude2.Reward(10);
dude2.Reward(6);
dude2.Reward(2);
dude2.Reward(1);

dude3.Reward(10);
dude3.Reward(6);
dude3.Reward(2);
dude3.Reward(8);
dude3.Reward(9);

var sortedDudes = dudes.OrderByDescending(o => o.TotalScore).ToList();


Console.WriteLine($"The employee of the week is {sortedDudes[0].Title} {sortedDudes[0].Name} {sortedDudes[0].Surname}, which scored {sortedDudes[0].TotalScore} points total. Congratulations!");



