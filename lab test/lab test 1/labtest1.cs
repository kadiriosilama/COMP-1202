
/*QUESTION 3:Write a program to allow a set of scores to be averaged. Allow any number
of scores to be entered but assume that the user always enters at least one score. User
indicates the end of entry by entering a negative number to terminate the loop. (3 points)
Add this feature to your application: (1 point)
• If the user enters zero number of score, your application should ask the user to enter
at least one number otherwise the average cannot be calculated.
*/


internal class question3
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter scores to be averaged. Enter a negative number to terminate input.");

        double sum = 0;
        int count = 0;

        while (true)
        {
            Console.Write("Enter a score: ");
            double score;
            if (!double.TryParse(Console.ReadLine(), out score))
            {
                Console.WriteLine("Invalid input. Please enter a valid score.");
                continue;
            }

            if (score < 0)
            {
                if (count == 0)
                {
                    Console.WriteLine("At least one score must be entered to calculate the average.");
                }
                else
                {
                    break;
                }
            }
            else
            {
                sum += score;
                count++;
            }
        }

        if (count > 0)
        {
            double average = sum / count;
            Console.WriteLine($"The average of the {count} scores entered is: {average}");
        }
    }
}
