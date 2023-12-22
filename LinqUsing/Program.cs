namespace LinqUsing
{
    class Program
    {
        public static void Main(string[] args)
        {
            //HomeWork 10
            //1Виведіть усі числа від 10 до 50 через кому
            Console.WriteLine(string.Join(", ", Enumerable
                .Range(10, 41)));

            // 2. Виведіть лише ті числа від 10 до 50, які можна поділити на 3
            Console.WriteLine(string.Join(", ", Enumerable
                .Range(10, 41)
                .Where(x => x % 3 == 0)));

            // 3. Виведіть слово "Linq" 10 разів
            Console.WriteLine(string.Concat(Enumerable
                .Repeat("Linq", 10)));

            // 4. Вивести всі слова з буквою «а» в рядку «aaa;abb;ccc;dap»
            Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';')
                .Where(s => s.Contains("a"))));

            // 5. Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa;abb;ccc;dap» через кому
            Console.WriteLine(string.Join(", ", "aaa;abb;ccc;dap".Split(';')
                .Select(s => s.Count(c => c == 'a'))));

            // 6. Вивести true, якщо слово "abb" існує в рядку "aaa;xabbx;abb;ccc;dap", інакше false
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';')
                .Any(s => s == "abb"));

            // 7. Отримати найдовше слово в рядку "aaa;xabbx;abb;ccc;dap"
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';')
                .OrderByDescending(s => s.Length)
                .First());

            // 8. Обчислити середню довжину слова в рядку "aaa;xabbx;abb;ccc;dap"
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';')
                .Select(s => s.Length)
                .Average());

            // 9. Вивести найкоротше слово в рядку "aaa;xabbx;abb;ccc;dap;zh" у зворотному порядку.
            Console.WriteLine("aaa;xabbx;abb;ccc;dap;zh".Split(';')
                .OrderBy(s => s.Length)
                .First()
                .Reverse()
                .ToArray());

            // 10. Вивести true, якщо в першому слові, яке починається з "aa", усі літери "b" (За винятком "аа"), інакше false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';')
                .First(s => s.StartsWith("aa"))
                .All(c => c == 'b'));

            // 11. Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на "bb" (використовуйте послідовність із 10 завдання)
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';')
                .Reverse()
                .Skip(2)
                .FirstOrDefault(s => !s.EndsWith("bb")) ?? "Слово не найдено");
        }
    }
}