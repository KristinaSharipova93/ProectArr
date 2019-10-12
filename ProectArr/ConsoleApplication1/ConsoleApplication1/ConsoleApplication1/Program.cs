using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1 {
    class Program {
        static Presentor presentor;
        static void Main(string[] args) {
            bool exit = false;
            presentor = new Presentor();
            while (!exit) {
                Console.WriteLine("Введите данные\n" +
                                "1 - Добавить элемент\n" +
                                "2 - Удалить элемент\n" +
                                "3 - Вывести значения массива\n" +
                                "4 - Сортировка\n" +
                                "0 - Выйти");
                String userAnswerStr = Console.ReadLine();
                int userAnswerInt = new int();
                if (!int.TryParse(userAnswerStr, out userAnswerInt)) continue;
                switch (userAnswerInt) {
                    case 0:
                        exit = true;
                        break;
                    case 1:
                        Add();
                        break;
                    case 2:
                        Delete();
                        break;
                    case 3:
                        Print();
                        break;
                    case 4:
                        Sort();
                        break;
                    default:
                        Console.WriteLine("Wrong number\n");
                        break;
                }
            }
        }

        static void Add()
        {
            Console.WriteLine("Введите число, которое хотите добавить");
            String userAnswer = Console.ReadLine();
            Console.WriteLine(presentor.Add(userAnswer));
        }

        static void Delete()
        {
            Console.WriteLine("Введите индекс числа, которое хотите удалить");
            String userAnswer = Console.ReadLine();
            Console.WriteLine(presentor.Delete(userAnswer));
        }
        
        static void Print()
        {
            Console.WriteLine(presentor.GetArrayString());
        }
        static void Sort()
        {
            presentor.SortArray();
        }
    }
}
