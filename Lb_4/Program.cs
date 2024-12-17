using System;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        // Встановлення кодування виводу в UTF-8 для коректного відображення символів
        Console.OutputEncoding = Encoding.UTF8;

        double min = double.MaxValue; // Мінімальне значення ініціалізовано максимально можливим значенням
        double max = double.MinValue; // Максимальне значення ініціалізовано мінімально можливим значенням
        // Оголошення масиву для збереження чисел
        double[] numbers = new double[10];
        double sum = 0; // Змінна для збереження суми чисел

        // Запит користувача на введення 10 чисел
        Console.WriteLine("Введіть 10 чисел:");

        // Цикл для введення чисел користувачем
        for (int i = 0; i < numbers.Length; i++)
        {
            while (true)
            {
                Console.Write($"Число {i + 1}: ");
                // Перевірка коректності введеного числа
                if (double.TryParse(Console.ReadLine(), out double num))
                {
                    numbers[i] = num; // Збереження введеного числа в масив
                    break; // Вихід з циклу після коректного введення
                }
                else
                {
                    // Повідомлення про помилку, якщо введене значення некоректне
                    Console.WriteLine("Будь ласка, введіть коректне число.");
                }
            }
        }

        // Виведення чисел у зворотному порядку
        Console.WriteLine("\nЧисла у зворотному порядку:");
        Console.WriteLine(string.Join(", ", numbers.Reverse()));

        // Обчислення суми, мінімального та максимального значення
        foreach (double num in numbers)
        {
            sum += num; // Сума всіх чисел
            if (num < min) min = num; // Оновлення мінімального значення
            if (num > max) max = num; // Оновлення максимального значення
        }

        // Обчислення середнього значення
        double average = sum / numbers.Length;
        // Обчислення медіани
        double median = CalculateMedian(numbers);

        // Виведення результатів
        Console.WriteLine($"\nСума: {sum}");
        Console.WriteLine($"Середнє значення: {average}");
        Console.WriteLine($"Медіана: {median}");
        Console.WriteLine($"Мінімальне значення: {min}");
        Console.WriteLine($"Максимальне значення: {max}");

        // Підрахунок кількості чисел, що більші за середнє значення
        int countAboveAverage = numbers.Count(num => num > average);
        Console.WriteLine($"Кількість чисел, що більші за середнє значення: {countAboveAverage}");

        // Виконання арифметичних операцій з першим та другим числом
        double firstNum = numbers[0];
        double secondNum = numbers[1];
        Console.WriteLine("\nАрифметичних операцій між першим і другим введеними числами:");
        Console.WriteLine($"Додавання: {Add(firstNum, secondNum)}");
        Console.WriteLine($"Віднімання: {Subtract(firstNum, secondNum)}");
        Console.WriteLine($"Множення: {Multiply(firstNum, secondNum)}");
        Console.WriteLine($"Ділення: {Divide(firstNum, secondNum)}");

        // Сортування масиву та виведення відсортованого масиву
        SortArray(numbers);
        Console.WriteLine("\nВідсортований масив:");
        Console.WriteLine(string.Join(", ", numbers));

        // Обчислення різниці між максимальним і мінімальним значенням
        double difference = max - min;
        Console.WriteLine($"Різниця між максимальним і мінімальним значенням: {difference}");
    }

    // Метод для обчислення медіани
    static double CalculateMedian(double[] array)
    {
        var sortedArray = array.OrderBy(num => num).ToArray(); // Сортування масиву
        int size = sortedArray.Length;
        if (size % 2 == 0)
        {
            // Якщо кількість елементів парна, медіана - середнє арифметичне двох середніх елементів
            return (sortedArray[size / 2 - 1] + sortedArray[size / 2]) / 2;
        }
        else
        {
            // Якщо кількість елементів непарна, медіана - середній елемент
            return sortedArray[size / 2];
        }
    }

    // Метод для сортування масиву
    static void SortArray(double[] array)
    {
        Array.Sort(array); // Сортування масиву за зростанням
    }

    // Метод для додавання двох чисел
    static double Add(double a, double b)
    {
        return a + b;
    }

    // Метод для віднімання двох чисел
    static double Subtract(double a, double b)
    {
        return a - b;
    }

    // Метод для множення двох чисел
    static double Multiply(double a, double b)
    {
        return a * b;
    }

    // Метод для ділення двох чисел
    static double Divide(double a, double b)
    {
        // Перевірка на ділення на нуль
        if (b == 0)
        {
            Console.WriteLine("Помилка: Ділення на нуль.");
            return double.NaN; // Повернення NaN у випадку ділення на нуль
        }
        return a / b;
    }
}
