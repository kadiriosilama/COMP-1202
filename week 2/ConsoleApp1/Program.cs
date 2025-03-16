// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
namespace ConsoleApp{
// single line comment
class Program
{
static void Main ( string [] args )
{
    int temperatureC;
    temperatureC = 32;

    double temperatureF;
    temperatureF = (temperatureC * 9/ 5) + 32;

Console.WriteLine ($"the temperature in C is equal to {temperatureC}");
Console.WriteLine ($"the temperature in C is equal to {temperatureF,-20:F2}");

temperatureC =0;
temperatureF = ((double)temperatureC * 9/ 5) + 32;
Console.WriteLine ($"the temperature in C is equal to {temperatureC}");
Console.WriteLine ($"the temperature in C is equal to {temperatureF,-20:F2}");
}
    }
        }

