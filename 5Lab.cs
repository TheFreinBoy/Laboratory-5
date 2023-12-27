using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_lab
{
    internal class Program
    {       
         static int[] RandomLines(int countelements) /*a*/
        {                        
             int[] array = new int[countelements];
            Random rndGen = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rndGen.Next(200) - 100;               
            }
            return array;
        }       
         static int[] ManuallySeparateLines(int countelements) /*b*/
        {
            Console.WriteLine("Введіть ці елементи");           
            int[] array = new int[countelements];
            for (int i = 0; i < countelements; i++)
            {
                array[i] = int.Parse(Console.ReadLine());               
            }
            return array;           
        }          
         static int[] ManuallyInOneLine() /*c*/
        {
            string[] input = Console.ReadLine().Trim().Split();
            int[] array = new int[input.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(input[i]);
            }           
            return array;
        }
        static void PrintArray(int[] array)
        {          
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.Write("\n");
        }
        //Variant 7:Замінити всі від’ємні числа на їхні модулі, після чого знайти серед усіх елементів масиву два мінімальних.
        static void Decision(int[] array)
        {           
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    array[i] = -array[i];                  
                }
            }
            PrintArray(array);
            int min = int.MaxValue;
            int prevmin = int.MaxValue;
            for (int i = 0; i < array.Length; i++)
            {           
                if (array[i] < min)
                {
                    prevmin = min;
                    min = array[i]; 
                }
                else if (array[i] < prevmin )
                {
                    prevmin = array[i];                   
                }
            }
            Console.WriteLine($"\nПеред-мінімальне число:{prevmin} ");
            Console.WriteLine($"Мінімальне число:{min}");          
        }      
        static void Main(string[] args)
        {
            int choice;
            int[] array;
            Console.OutputEncoding = Encoding.UTF8;
            do
            {
                Console.WriteLine("\nВведіть 1, якщо бажаєте ввести випадково");
                Console.WriteLine("Введіть 2, якщо бажаєте ввести вручну в окремих рядках");
                Console.WriteLine("Введіть 3, якщо бажаєте ввести вручну в одному рядку");
                Console.WriteLine("Для виходу з програми введіть 0");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Введіть кількість елементів:");
                        array = RandomLines(int.Parse(Console.ReadLine()));
                        PrintArray(array);
                        Decision(array);
                        break;
                    case 2:
                        Console.WriteLine("Введіть кількість елементів:");
                        array = ManuallySeparateLines(int.Parse(Console.ReadLine()));
                        PrintArray(array);
                        Decision(array);
                        break;
                    case 3:
                        Console.WriteLine("Введіть елементи:");
                        array = ManuallyInOneLine();
                        Decision(array);
                        break;
                    case 0:
                        Console.WriteLine("Натисніть ще раз для завершення");
                        break;
                    default:
                        Console.WriteLine("Оберіть варіант ведення ще раз, натисніть 1, 2 або 3!");
                        break;          
                }
            } while (choice != 0);
        }
    }
}
