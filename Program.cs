namespace Tasks
{
    static class Program
    {
        public static void Main(string[] args)
        {
            Console.Clear();
            string stringLoad = "Введите номер задачи (от 1 до 3) : ";
            Console.Write(stringLoad);
            Tasks(NumberInTerminal(3, stringLoad, 1));
        }
        static void Tasks(int num)
        {
            switch (num)
            {
                case 1:
                    {
                        Console.WriteLine("Задача 1: Задайте значения M и N. Напишите программу, которая выведет ");
                        Console.WriteLine("все натуральные числа в промежутке от M до N. Использовать рекурсию, не использовать циклы.");
                        string firstText = "Введите значение М : ";
                        Console.Write(firstText);
                        int firstNumber = NumberInTerminal(0xFFFFFF, firstText, 1);
                        string secondText = "Введите значение N : ";
                        Console.Write(secondText);
                        int secondNumber = NumberInTerminal(0xFFFFFF, secondText, 1);
                        Console.WriteLine($"Числа от {firstNumber} до {secondNumber} : {ShowDigit(firstNumber, secondNumber)}");
                        break;

                    }
                case 2:
                    {
                        Console.Write("Введите число M: ");
                        int m = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите число N: ");
                        int n = Convert.ToInt32(Console.ReadLine());
                        AkkermanFunction(m, n);
                        void AkkermanFunction(int m, int n)
                        {
                            Console.Write(Akkerman(m, n));
                        }
                        int Akkerman(int m, int n)
                        {
                            if (m == 0)
                            {
                                return n + 1;
                            }
                            else if (n == 0 && m > 0)
                            {
                                return Akkerman(m - 1, 1);
                            }
                            else
                            {
                                return (Akkerman(m - 1, Akkerman(m, n - 1)));
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Задача 3: Задайте произвольный массив. Выведете его элементы,");
                        Console.WriteLine("начиная с конца. Использовать рекурсию, не использовать циклы.");
                        int[] array = CreateArray(10, 10, 0);
                        Console.WriteLine($"Произвольный массив : [{PrintArray(array)}]");
                        Console.WriteLine($"Перевернутый массив : [{PrintArray(ArraySwap(array, array.Length - 1))}]");
                        break;
                    }
            }
        }
        public static int[] CreateArray(int size, int max, int min)
        {
            int[] array = new int[size];
            Random rand = new();
            for (int i = 0; i < size; i++)
            {
                array[i] = rand.Next(min, max + 1);
            }
            return array;
        }
        public static string PrintArray(int[] array)
        {
            return string.Join(", ", array);
        }
        public static int[] ArraySwap(int[] array, int index)
        {

            if (index <= 0)
            {
                return array;
            }
            int temp = array[index];
            array[index] = array[array.Length - index - 1];
            array[array.Length - index - 1] = temp;
            return ArraySwap(array, index -= 2);
        }
        public static int Ack(int m, int n)
        {
            if (m == 0)
            {
                return n + 1;
            }
            else
            {
                if (n == 0)
                {
                    return Ack(m - 1, 1);
                }
                else
                {
                    return Ack(m - 1, Ack(m, n - 1));
                }
            }
        }
        public static string ShowDigit(int firstDigit, int secondDigit)
        {
            if (firstDigit > secondDigit)
            {
                return "";
            }
            return $"{firstDigit} " + ShowDigit(firstDigit + 1, secondDigit);
        }
        /*Функция ввода чисел в терминале*/
        public static int NumberInTerminal(int numberDigits, string repeatString, int minValueSet)
        {
            string? numString = Console.ReadLine();
            int numInt = 0;
            while ((!Int32.TryParse(numString, out numInt))
                    || !(numInt >= minValueSet)
                    || !(numInt <= numberDigits)
                  )
            {
                Console.WriteLine("Ошибка ввода, повторите :");
                Console.Write(repeatString);
                numString = Console.ReadLine();
            }
            return numInt;
        }

        public static void PrintArray(char[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            string output = "";
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    output += array[i, j] + " ";
                }
                Console.WriteLine($"[ {output}]");
                output = "";
            }
        }
    }
}