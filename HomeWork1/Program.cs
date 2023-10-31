namespace HomeWork1
{
    class Program
    {
        static void Main()
        {
            //1. Знайти позицію літери в алфавіті та перевести її в інший регістр
            Console.WriteLine("\nTask 1");

            char letter = 'Y'; // The letter we are looking for (e.g., 'Y')

            int position = (int)char.ToUpper(letter) - (int)'A' + 1; //Convert letter to upperCase and Find the position of the letter in the alphabet
            char otherCase = char.IsUpper(letter) ? char.ToLower(letter) : char.ToUpper(letter); // Change the letter's case

            Console.WriteLine($"Letter: {letter}");
            Console.WriteLine($"Position in the alphabet: {position}");
            Console.WriteLine($"Letter in the other case: {otherCase}");
            //2.Розділювач рядка.
            //Дана строка та символ, потрібно розділити строку на кілька строк (масив строк) виходячи із заданого символу.
            //Наприклад: строка = "Лондон, Париж, Рим", а символ = ','. Результат = string[] { "Лондон", "Париж", "Рим" }.
            Console.WriteLine("\nTask 2");
            string userInput = "London, Paris, Rome.";
            char[] separators = new char[] { ' ', ',', '.', '!', '?' }; // Масив символів роздільників

            Console.WriteLine("Example string: " + userInput);
            List<string> words = new List<string>();
            string word = "";
            foreach (char character in userInput)
            {
                if (separators.Contains(character))
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        words.Add(word);
                        word = "";
                    }
                }
                else
                {
                    word += character;
                }
            }

            if (!string.IsNullOrEmpty(word))
            {
                words.Add(word);
            }

            foreach (string w in words)
            {
                Console.WriteLine(w);
            }
            //3. Пошук підстроки у строці
            Console.WriteLine("\nTask 3");
            string mainString = "This is an example string where the example is repeated. Example."; // The main string in which we are searching for a substring
            string subString = "example"; // The substring we are looking for
            int mainStringLength = mainString.Length; // The length of the main string
            int subStringLength = subString.Length; // The length of the substring

            for (int i = 0; i <= mainStringLength - subStringLength; i++)
            {
                if (mainString[i] == subString[0]) // Compare the current character of the main string with the first character of the substring
                {
                    bool found = true; // A variable to track whether the substring is found
                    for (int j = 1; j < subStringLength; j++)
                    {
                        if (mainString[i + j] != subString[j]) // Compare the other characters of the substring with the main string
                        {
                            found = false; // If at least one character doesn't match, set that the substring is not found
                            break; // Exit the loop
                        }
                    }
                    if (found)
                    {
                        Console.WriteLine($"Found the substring '{subString}' at position {i}"); // Print the position of the found substring
                    }
                }
            }

            //4. Написати програму, яка виводить число літерами. Приклад: 117 - сто сімнадцять
            int number;
            Console.WriteLine("\nTask 4\nEnter number to convert it to words");
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number < -999_999_999 || number > 999_999_999)
                {
                    Console.WriteLine("The number is out of the supported range.");
                }
                else
                {
                    string byWords = NumberToWords(number);
                    Console.WriteLine($"{number} - {byWords}");
                }
            }
            else
            {
                Console.WriteLine("Invalid input for the number.");
            }


            //5. Поміняти місцями значення двох змінних (типу int) (без використання 3й)
            Console.WriteLine("\nTask 5\nfirst variant of task 5");
            ////1
            int num1 = 3;
            int num2 = 5;

            Console.WriteLine($"number 1 is: {num1}, number 2 is: {num2}");

            num1 = num1 ^ num2;
            num2 = num1 ^ num2;
            num1 = num1 ^ num2;

            //Опис, розглянемо числа 3 та 5 у двоїчній системі, 3 - 0011, 5 - 0101.застосовуючи побітове виключення OR
            //    X         Y       X^Y
            //    1         1        0
            //    1         0        1
            //    0         1        1
            //    0         0        0


            //На 14 строке: a = a ^ b => 0011 ^ 0101 => 0110 => 6
            //На 15 строке: b = a ^ b => 0110 ^ 0101 => 0011 => 3
            //На 16 строке: a = a ^ b => 0110 ^ 0011 => 0101 => 5

            Console.WriteLine($"number 1 is: {num1}, number 2 is: {num2}");
            ////2

            Console.WriteLine("\nSecond variant");

            num1 = 10;
            num2 = 20;

            Console.WriteLine($"number 1 is: {num1}, number 2 is: {num2}");

            num1 = num1 * num2;
            num2 = num1 / num2;
            num1 = num1 / num2;

            Console.WriteLine($"number 1 is: {num1}, number 2 is: {num2}");

            Console.ReadKey();
        }
        //4.
        // Arrays for defining words for units, teens, tens, and thousands.
        static string[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        static string[] teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        static string[] tens = { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        static string[] thousands = { "", "thousand", "million", "billion", "trillion", "quadrillion" };

        // Method to convert a number to words.
        static string NumberToWords(int number)
        {
            if (number == 0)
                return units[0];

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";


            // Loop through the number, processing it in groups of three digits.
            for (int i = 0; number > 0; i++)
            {
                int remainder = number % 1000;
                if (remainder != 0)
                {
                    // Convert the current three-digit group to words and add the appropriate thousands unit.
                    words = $"{NumberToWordsLessThanThousand(remainder)} {thousands[i]} {words}";
                }
                number /= 1000; // Move to the next three-digit group.
            }

            return words.Trim();
        }

        // Method to convert a three-digit number to words.
        static string NumberToWordsLessThanThousand(int number)
        {
            if (number < 10)
                return units[number];
            else if (number < 20)
                return teens[number - 10];
            else
            {
                int hundredsDigit = number / 100;
                int tensDigit = (number % 100) / 10;
                int unitsDigit = number % 10;

                string result = "";

                if (hundredsDigit > 0)
                {
                    result = $"{units[hundredsDigit]} hundred";
                    if (tensDigit > 0 || unitsDigit > 0)
                    {
                        result += " and ";
                    }
                }

                if (tensDigit == 1)
                {
                    result += teens[unitsDigit];
                }
                else if (tensDigit > 1)
                {
                    result += tens[tensDigit];
                    if (unitsDigit > 0)
                    {
                        result += " " + units[unitsDigit];
                    }
                }
                else if (unitsDigit > 0)
                {
                    result += units[unitsDigit];
                }

                return result;
            }
        }
    }
}