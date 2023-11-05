using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Channels;
using System.Transactions;
using System.Security.Cryptography;

namespace HomeWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Реверс строки/масиву. Без додаткового масиву. Складність О(n).
            Console.WriteLine("Task 1");
            static void ReverseArray(int[] reverseArray)
            {
                int leftEdge = 0;
                int rightEdge = reverseArray.Length - 1;

                while (leftEdge < rightEdge)
                {
                    int buff = reverseArray[leftEdge];
                    reverseArray[leftEdge] = reverseArray[rightEdge];
                    reverseArray[rightEdge] = buff;

                    leftEdge++;
                    rightEdge--;
                }
            }

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Console.WriteLine("Entered array: " + string.Join(", ", numbers));

            ReverseArray(numbers);

            Console.WriteLine("Reversed array: " + string.Join(", ", numbers));
            Console.WriteLine();

            //2. Фільтрування неприпустимих слів у строці. Має бути саме слова, а не частини слів.
            Console.WriteLine("Task 2");
            static string FilterForbiddenWords(string input, string[] forbiddenWords)
            {
                string pattern = @"\b(" + string.Join("|", forbiddenWords.Select(Regex.Escape)) + @")\b";
                string filteredText = Regex.Replace(input, pattern, "***", RegexOptions.IgnoreCase);

                return filteredText;
            }

            string example = "... Those that would survive or be victorious against an assault," +
                " would raise those fingers to the opposing forces as a sign of \n“fuck you, I still have these fingers and I can use them to shoot you!” " +
                "\nEuropeans still use this sign to say “fuck you!”;";

            string[] forbiddenWords = { "fuck" };

            string filteredText = FilterForbiddenWords(example, forbiddenWords);

            Console.WriteLine(filteredText + "\n");

            //3. Генератор випадкових символів. На вхід кількість символів, на виході рядок з випадковими символами.
            Console.WriteLine("Task 3");
            Random random = new Random();

            Console.WriteLine("Enter amount of random sumbols: ");
            int sumbolAmount = int.Parse(Console.ReadLine());

            string randSumbolString = "";
            for (int i = 0; i < sumbolAmount; i++)
            {
                char randSumbol = (char)random.Next(33, 127);
                randSumbolString += randSumbol;
            }

            Console.WriteLine(randSumbolString + "\n");

            //4. "Дірка" (пропущене число) у масиві.
            //Масив довжини N у випадковому порядку заповнений цілими числами з діапазону від 0 до N.
            //Кожне число зустрічається в масиві не більше одного разу. Знайти відсутнє число (дірку).
            //Є дуже простий та оригінальний спосіб вирішення.
            //Складність алгоритму O(N). Використання додаткової пам'яті, пропорційної довжині масиву не допускається.
            Console.WriteLine("Task 4");
            static int FindMissingNumber(int[] arr, int n)
            {
                if (Array.IndexOf(arr, 0) == -1) n += 1;
                int expectedSum = (n * (n + 1)) / 2;
                int actualSum = 0;
                foreach (int num in arr)
                {
                    actualSum += num;
                }

                int missingNumber = expectedSum - actualSum;

                return missingNumber;
            }

            static int[] GenerateArrayWithMissingNumber(int N)
            {
                int missingNumber = new Random().Next(N + 1);
                int[] arr = new int[N];

                for (int i = 0, j = 0; i <= N; i++)
                {
                    if (i != missingNumber)
                    {
                        arr[j] = i;
                        j++;
                    }
                }

                return arr;
            }


            Console.WriteLine("Enter the length of array: ");

            int N = int.Parse(Console.ReadLine());
            int[] arr = GenerateArrayWithMissingNumber(N);
            int missingNumber = FindMissingNumber(arr, N);

            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }

            Console.WriteLine("\nThe missing number is: {0}", missingNumber);

            //5.Найпростіше стиснення ланцюжка ДНК.
            //Ланцюг ДНК у вигляді строки на вхід (кожен нуклеотид представлений символом А = 00, C = 01, G = 10, T = 11).
            //Два методи, один для компресії, інший для декомпресії.
            Console.WriteLine("Task 4");
            static string CompressDNA(string userDNA)
            {
                StringBuilder compressed = new StringBuilder();
                foreach (char nucliotide in userDNA)
                {
                    switch (nucliotide)
                    {
                        case 'A': compressed.Append("00"); break;
                        case 'C': compressed.Append("01"); ; break;
                        case 'G': compressed.Append("10"); break;
                        case 'T': compressed.Append("11"); break;
                        default: Console.WriteLine("Wrong Nucleotide"); break;
                    }
                }
                return compressed.ToString();

            }
            static string DecompressDNA(string compresedDNA)
            {
                StringBuilder decompressed = new StringBuilder();
                for (int i = 0; i < compresedDNA.Length; i += 2)
                {
                    string nucleotide = compresedDNA.Substring(i, 2);
                    switch (nucleotide)
                    {
                        case "00": decompressed.Append("A"); break;
                        case "01": decompressed.Append("C"); ; break;
                        case "10": decompressed.Append("G"); break;
                        case "11": decompressed.Append("T"); break;
                        default: Console.WriteLine("Wrong Nucleotide"); break;
                    }
                }
                return decompressed.ToString();
            }
            string originalDNA = "ACGTACTGCTGATCAGTAGC";
            string compressedDNA = CompressDNA(originalDNA);
            string decompressedDNA = DecompressDNA(compressedDNA);

            Console.WriteLine("Original DNA strand: " + originalDNA);
            Console.WriteLine("Compressed DNA strand: " + compressedDNA);
            Console.WriteLine("Decompressed DNA strand: " + decompressedDNA + "\n");

            //6.Симетричне шифрування.
            //Є строка на вхід, який має бути зашифрований.
            //Ключ можна задати в коді або згенерувати та зберегти.
            //Два методи, шифрування та дешифрування.
            
            string key = "4z3V61mh52833Ra7"; //key mast be 16 chars long

            string Encrypt(string plainText)
            {

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = new byte[16];

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var msEncrypt = new System.IO.MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        using (var swEncrypt = new System.IO.StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return Convert.ToBase64String(msEncrypt.ToArray());
                    }
                }
            }
            string Decrypt(string cipherText)
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = Encoding.UTF8.GetBytes(key);
                    aesAlg.IV = new byte[16];

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new System.IO.MemoryStream(Convert.FromBase64String(cipherText)))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        using (var srDecrypt = new System.IO.StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            string originalText = "Hello world of encryption!";

            string encryptedText = Encrypt(originalText);
            Console.WriteLine("Encrypted: " + encryptedText);

            string decryptedText = Decrypt(encryptedText);
            Console.WriteLine("Decrypted: " + decryptedText);
            Console.ReadKey();
        }
    }
}
