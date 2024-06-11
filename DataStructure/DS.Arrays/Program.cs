Methods functions = new Methods();
int[] numbers = new int[3];
functions.PrintIntArray(numbers);

Console.WriteLine("Length: " + numbers.Length);
Console.WriteLine();

numbers[0] = 10;
numbers[1] = 20;
numbers[2] = 30;
functions.PrintIntArray(numbers);

Console.WriteLine("Length: " + numbers.Length);
Console.WriteLine();


public class Methods
{
    public void PrintIntArray(int[] numbers)
    {
        foreach (int i in numbers)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine("-----------------------------------");
    }

}