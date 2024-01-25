using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.Write("Введіть розмір масиву: ");
        int arraySize = int.Parse(Console.ReadLine());

        Console.Write("Введіть кількість потоків: ");
        int threadCount = int.Parse(Console.ReadLine());

        // Створення масиву
        int[] array = new int[arraySize];
        Random random = new Random();
        for (int i = 0; i < arraySize; i++)
        {
            array[i] = random.Next(1, 100);
        }

        // Створення об'єкта для кожного завдання
        MinTask minTask = new MinTask(array);
        MaxTask maxTask = new MaxTask(array);
        SumTask sumTask = new SumTask(array);
        AverageTask averageTask = new AverageTask(array);
        CopyTask copyTask = new CopyTask(array);
        FrequencyCharacterTask charFrequencyTask = new FrequencyCharacterTask("some_long_text");
        FrequencyWordTask wordFrequencyTask = new FrequencyWordTask("some_long_text");

        // Запуск завдань в паралелі
        Thread[] threads = new Thread[threadCount];
        threads[0] = new Thread(() => minTask.Execute());
        threads[1] = new Thread(() => maxTask.Execute());
        threads[2] = new Thread(() => sumTask.Execute());
        threads[3] = new Thread(() => averageTask.Execute());
        threads[4] = new Thread(() => copyTask.Execute());
        threads[5] = new Thread(() => charFrequencyTask.Execute());
        threads[6] = new Thread(() => wordFrequencyTask.Execute());

        for (int i = 0; i < threadCount; i++)
        {
            threads[i].Start();
        }

        for (int i = 0; i < threadCount; i++)
        {
            threads[i].Join();
        }

        Console.WriteLine("Всі завдання виконано.");
    }
}

// Базовий клас для завдань
abstract class TaskBase
{
    protected readonly int[] Array;
    protected readonly object LockObject = new object();

    protected TaskBase(int[] array)
    {
        Array = array;
    }

    public abstract void Execute();
}

// Завдання для знаходження мінімуму в масиві
class MinTask : TaskBase
{
    public MinTask(int[] array) : base(array) { }

    public override void Execute()
    {
        int min = int.MaxValue;
        foreach (int number in Array)
        {
            if (number < min)
            {
                min = number;
            }
        }

        lock (LockObject)
        {
            Console.WriteLine("Мінімум в масиві: " + min);
        }
    }
}

// Завдання для знаходження максимуму в масиві
class MaxTask : TaskBase
{
    public MaxTask(int[] array) : base(array) { }

    public override void Execute()
    {
        int max = int.MinValue;
        foreach (int number in Array)
        {
            if (number > max)
            {
                max = number;
            }
        }

        lock (LockObject)
        {
            Console.WriteLine("Максимум в масиві: " + max);
        }
    }
}

// Завдання для знаходження суми елементів масиву
class SumTask : TaskBase
{
    public SumTask(int[] array) : base(array) { }

    public override void Execute()
    {
        int sum = 0;
        foreach (int number in Array)
        {
            sum += number;
        }

        lock (LockObject)
        {
            Console.WriteLine("Сума елементів масиву: " + sum);
        }
    }
}

// Завдання для знаходження середнього значення в масиві
class AverageTask : TaskBase
{
    public AverageTask(int[] array) : base(array) { }

    public override void Execute()
    {
        double sum = 0;
        foreach (int number in Array)
        {
            sum += number;
        }

        double average = sum / Array.Length;

        lock (LockObject)
        {
            Console.WriteLine("Середнє значення в масиві: " + average);
        }
    }
}

// Завдання для копіювання частини масиву
class CopyTask : TaskBase
{
    public CopyTask(int[] array) : base(array) { }

    public override void Execute()
    {
        int[] copyArray = new ArraySegment<int>(Array, 0, Array.Length / 2).ToArray();

        lock (LockObject)
        {
            Console.WriteLine("Копія частини масиву: " + string.Join(", ", copyArray));
        }
    }
}

// Завдання для створення частотного словника символів
class FrequencyCharacterTask : TaskBase
{
    private readonly string text;

    public FrequencyCharacterTask(string text) : base(null)
    {
        this.text = text;
    }

    public override void Execute()
    {
        Dictionary<char, int> frequencyDictionary = new Dictionary<char, int>();
        foreach (char character in text)
        {
            if (frequencyDictionary.ContainsKey(character))
            {
                frequencyDictionary[character]++;
            }
            else
            {
                frequencyDictionary[character] = 1;
            }
        }

        lock (LockObject)
        {
            Console.WriteLine("Частотний словник символів: ");
            foreach (var entry in frequencyDictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}

// Завдання для створення частотного словника слів
class FrequencyWordTask : TaskBase
{
    private readonly string text;

    public FrequencyWordTask(string text) : base(null)
    {
        this.text = text;
    }

    public override void Execute()
    {
        string[] words = text.Split(' ');
        Dictionary<string, int> frequencyDictionary = new Dictionary<string, int>();
        foreach (string word in words)
        {
            string cleanedWord = word.Trim('.', '.', '?', '!', ';', ':', '-');
            if (frequencyDictionary.ContainsKey(cleanedWord))
            {
                frequencyDictionary[cleanedWord]++;
            }
            else
            {
                frequencyDictionary[cleanedWord] = 1;
            }
        }

        lock (LockObject)
        {
            Console.WriteLine("Частотний словник слів: ");
            foreach (var entry in frequencyDictionary)
            {
                Console.WriteLine($"{entry.Key}: {entry.Value}");
            }
        }
    }
}
