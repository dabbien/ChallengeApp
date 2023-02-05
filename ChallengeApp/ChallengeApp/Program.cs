int number = 4566;
string numberInString = number.ToString();
char[] numbers = numberInString.ToArray();
int[] result = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

foreach (char digit in numbers)
{
    int index = digit - '0';
    result[index]++;
}

for (int i = 0; i < result.Length; i++)
{
    Console.WriteLine($"{i} => {result[i]}");
}