string name = "";
char sex = 'm';
int age = 17;

if (sex.ToString().Length != 0)
    if (age < 18)
    {
        if (sex == 'F' || sex == 'f')
        {
            Console.WriteLine("The person is an underaged female.");
        }
        else if (sex == 'M' || sex == 'm')
        {
            Console.WriteLine("The person is an underaged male.");
        }
        else
        {
            Console.WriteLine("Please select persons sex in a single letter format: F - for a female, M - for a male.");
        }
    }
    else
    {
        if (name.Length == 0)
        {
            if (sex == 'F' || sex == 'f')
            {
                if (age < 30)
                {
                    Console.WriteLine("The person is a female under 30 years old.");
                }
                else
                {
                    Console.WriteLine("The person is a female over 30 years old.");
                }
            }
            else if (sex == 'M' || sex == 'm')
            {
                if (age < 30)
                {
                    Console.WriteLine("The person is a male under 30 years old.");
                }
                else
                {
                    Console.WriteLine("The person is a male over 30 years old.");
                }
            }
            else
            {
                Console.WriteLine("Please select persons sex in a single letter format: F - for a female, M - for a male.");
            }
        }
        else
        {
            Console.WriteLine(name + ", " + age + " years old.");
        }
    }
else
{
    Console.WriteLine("Please select persons sex in a single letter format: F - for a female, M - for a male.");
}