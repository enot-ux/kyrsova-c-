using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть ваш зріст (у метрах):");
        double height = GetValidDoubleInput();

        Console.WriteLine("Введіть вашу масу (у кілограмах):");
        double weight = GetValidDoubleInput();

        double bmi = CalculateBMI(height, weight);
        Console.WriteLine($"Ваш ІМТ: {bmi:F2}");

        double bmr = CalculateBMR(weight, height);
        Console.WriteLine($"Середня кількість калорій на день: {bmr:F2}");

        Console.WriteLine("Оберіть ціль:");
        Console.WriteLine("1. Схуднення");
        Console.WriteLine("2. Підтримання ваги");
        Console.WriteLine("3. Набір ваги");
        int goal = GetValidGoalInput();

        double caloriesPerDay = CalculateCaloriesPerDay(bmr, goal);
        Console.WriteLine($"Щоб досягти цілі, слід споживати {caloriesPerDay:F2} калорій на день");
    }

    static double GetValidDoubleInput()
    {
        double value;
        while (!double.TryParse(Console.ReadLine(), out value) || value <= 0) {
            Console.WriteLine("Введено некоректне значення. Будь ласка, спробуйте ще раз:");
        }
        return value;
    }

    static int GetValidGoalInput()
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value is < 1 or > 3) {
            Console.WriteLine("Введено некоректну ціль. Будь ласка, оберіть 1, 2 або 3:");
        }
        return value;
    }

    static double CalculateBMI(double height, double weight)
    {
        return weight / (height * height);
    }

    static double CalculateBMR(double weight, double height)
    {
        return 10 * weight + 6.25 * height * 100 - 5 * 25 + 5;
    }

    static double CalculateCaloriesPerDay(double bmr, int goal)
    {
        double factor;
        switch (goal)
        {
            case 1: // Схуднення
                factor = 0.8;
                break;
            case 2: // Підтримання ваги
                factor = 1.0;
                break;
            case 3: // Набір ваги
                factor = 1.2;
                break;
            default:
                factor = 1.0;
                break;
        }
        return bmr * factor;
    }
}