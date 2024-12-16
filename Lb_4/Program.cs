using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        double[] numbers = new double[10];
        Console.WriteLine("Введіть 10 чисел:");

        for (int i = 0; i < numbers.Length; i++)
        {
            while (true)
            {
                Console.Write($"Число {i + 1}: ");
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    numbers[i] = num;
                    break;
                }
                else
                {
                    Console.WriteLine("Будь ласка, введіть коректне число.");
                }
            }
        }

        Console.WriteLine("\nЧисла у зворотному порядку:");
        Console.WriteLine(string.Join(", ", numbers.Reverse()));

        double sum = numbers.Sum();
        double average = numbers.Average();
        double median = CalculateMedian(numbers);
        Console.WriteLine($"Сума: {sum}");
        Console.WriteLine($"Середнє значення: {average}");
        Console.WriteLine($"Медіана: {median}");

        double maxNum = numbers.Max();
        double minNum = numbers.Min();
        Console.WriteLine($"Максимальне значення: {maxNum}");
        Console.WriteLine($"Мінімальне значення: {minNum}");

        int countAboveAverage = numbers.Count(num => num > average);
        Console.WriteLine($"Кількість чисел, що більші за середнє значення: {countAboveAverage}");

        SortArray(numbers);
        Console.WriteLine("\nВідсортований масив:");
        Console.WriteLine(string.Join(", ", numbers));

        double difference = maxNum - minNum;
        Console.WriteLine($"Різниця між максимальним і мінімальним значенням: {difference}");

        double firstNum = numbers[0];
        double secondNum = numbers[1];
        Console.WriteLine($"Додавання: {Add(firstNum, secondNum)}");
        Console.WriteLine($"Віднімання: {Subtract(firstNum, secondNum)}");
        Console.WriteLine($"Множення: {Multiply(firstNum, secondNum)}");
        Console.WriteLine($"Ділення: {Divide(firstNum, secondNum)}");
    }

    static double CalculateMedian(double[] array)
    {
        var sortedArray = array.OrderBy(num => num).ToArray();
        int size = sortedArray.Length;
        if (size % 2 == 0)
        {
            return (sortedArray[size / 2 - 1] + sortedArray[size / 2]) / 2;
        }
        else
        {
            return sortedArray[size / 2];
        }
    }

    static void SortArray(double[] array)
    {
        Array.Sort(array);
    }

    static double Add(double a, double b)
    {
        return a + b;
    }

    static double Subtract(double a, double b)
    {
        return a - b;
    }

    static double Multiply(double a, double b)
    {
        return a * b;
    }

    static double Divide(double a, double b)
    {
        if (b == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль.");
            return double.NaN;
        }
        return a / b;
    }
}
