using System;

namespace BanknoteCombinations
{
    class Programm
    {
        static void Main(string[]args)
        {
            int targetSum;
            if(!int.TryParse(Console.ReadLine(),out targetSum ) || targetSum%100!=0 || targetSum>50000) 
            {
                Console.WriteLine("Ошибка ввода суммы. Пожалуйста, введите сумму кратную 100 руб. и не превышающую 50000 руб.");
                return;
            }
            //if(targetSum%100!=0)

            int[] banknotes = { 100, 200, 500, 1000, 2000, 5000 };
            int combinations = CountCombinations(targetSum, banknotes);
            Console.WriteLine($"Колличество способов набрать сумму {targetSum} руб. с использованием купюр достоинством 100, 200, 500, 1000, 2000 и 5000 руб.:{combinations}");
        }
        static int CountCombinations(int targetSum, int[] banknotes)
        {
            int[] combinations = new int[targetSum + 1];
            combinations[0] = 1;
            for(int i=0;i<banknotes.Length;i++)
            {
                for(int j = banknotes[i];j<=targetSum;j++)
                {
                    combinations[j] += combinations[j - banknotes[i]];
                }
            }
            return combinations[targetSum];
        }
    }
}

