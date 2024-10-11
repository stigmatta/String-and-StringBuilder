using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_and_StringBuilder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task3
            //Пользователь вводит строку с клавиатуры.Необходи -
            //мо зашифровать данную строку используя шифр Цезаря.
            //Шифр Цезаря — это вид шифра подстановки, в ко -
            //тором каждый символ в открытом тексте заменяется
            //символом, находящимся на некотором постоянном числе
            //позиций левее или правее него в алфавите. Например,
            //в шифре со сдвигом вправо на 3, A была бы заменена на
            //D, B станет E, и так далее.
            //Подробнее тут: https://en.wikipedia.org/wiki/Caesar_
            //            cipher.
            //Кроме механизма шифровки, реализуйте механизм
            //расшифрования.

            string cesaro = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.";
            StringBuilder sbInput = new StringBuilder(cesaro);
            Random rnd = new Random();
            int shift = 3 /*rnd.Next(1, 10)*/;

            for(int i = 0; i < sbInput.Length; i++)
            {
                int tmp = 0;
                while (tmp < shift)
                {

                    if (sbInput[i] == 'z' || sbInput[i] == 'Z')
                    {
                        sbInput[i] = (char)(sbInput[i]-25);
                        tmp++;
                    }

                    if (tmp == shift)
                        break;

                    if (Char.IsLetter(sbInput[i]))
                    {
                        sbInput[i] = (char)(sbInput[i] + 1);
                        tmp++;
                    }
                    else
                        break;
                }
                
            }

            Console.WriteLine(sbInput.ToString());

            #endregion

            #region Task5
            // Пользователь с клавиатуры вводит в строку арифметическое выражение.
            // Приложение должно посчитать его результат. Необходимо поддерживать только две операции: + и -.
            Console.WriteLine("Введите арифметическое выражение (с операциями + и -):");
            string expression = Console.ReadLine();

            expression = expression.Replace(" ", "");

            char[] strArr = expression.ToCharArray();
            string[] splittedArr = new string[strArr.Length];
            int tmp = 0;

            for (int i = 0; i < strArr.Length;)
            {
                if (strArr[i] == '-' || strArr[i] == '+')
                    splittedArr[tmp++] = strArr[i++].ToString();

                string currentNumber = string.Empty;

                while (i < strArr.Length && Char.IsDigit(strArr[i]))
                    currentNumber += strArr[i++];

                if (!string.IsNullOrEmpty(currentNumber))
                    splittedArr[tmp++] = currentNumber;
            }

            Array.Resize(ref splittedArr, tmp);

            double result = 0;
            double num = 0;
            char lastOperator = '+';

            foreach (string part in splittedArr)
            {
                if (double.TryParse(part, out num))
                {
                    if (lastOperator == '+')
                        result += num;
                    else if (lastOperator == '-')
                        result -= num;
                }
                else
                    lastOperator = part[0];
            }

            Console.WriteLine(result.ToString());
            #endregion


            #region Task6
            //Пользователь с клавиатуры вводит некоторый текст.
            //Приложение должно изменять регистр первой буквы
            //каждого предложения на букву в верхнем регистре.

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Console.ReadLine());


            for (int i = 0; i < sb.Length; i++)
            {
                if (i == 0 || (sb[i - 1] == '.') && sb[i] > 'a' && sb[i] < 'z')
                    sb[i] = Char.ToUpper(sb[i]);
            }

            Console.WriteLine(sb.ToString());


            #endregion
            #region Task7
            // Создайте приложение, проверяющее текст на недопустимые слова.
            // Если недопустимое слово найдено, оно должно быть заменено на набор символов *.
            // По итогам работы приложения необходимо показать статистику действий.
            string value = "To be, or not to be, that is the question,\r\nWhether 'tis nobler in the mind to suffer\r\n" +
                           "The slings and arrows of outrageous fortune,\r\nOr to take arms against a sea of troubles,\r\n" +
                           "And by opposing end them? To die: to sleep;\r\nNo more; and by a sleep to say we end\r\n" +
                           "The heart-ache and the thousand natural shocks\r\nThat flesh is heir to, 'tis a consummation\r\n" +
                           "Devoutly to be wish'd. To die, to sleep";

            string[] words = { "die", "end" };

            StringBuilder sb = new StringBuilder(value);
            int totalReplacements = 0;

            foreach (string word in words)
            {
                int wordLength = word.Length;
                int index = sb.ToString().IndexOf(word);

                while (index != -1)
                {
                    sb.Remove(index, wordLength);
                    sb.Insert(index, new string('*', wordLength));
                    totalReplacements++;
                    index = sb.ToString().IndexOf(word, index);
                }
            }

            Console.WriteLine("Результат:\n" + sb.ToString());
            Console.WriteLine($"\nКоличество замен: {totalReplacements}");
            #endregion
        }
    }
}
