using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Comporator : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            if(x < y)
            {
                return 1;
            }
            else if(x > y)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
    public class Presentor
    {
        Random random = new Random();
        private int[] array;
        private int arrayLength;
        public Presentor()
        {
            arrayLength = 10;
            array = new int[arrayLength];
            //заполнение массива
            for (int i = 0; i < 10; i++) { array[i] = random.Next(0, 1000); }
        }

        public String Add(String digitStr)
        {
            String message = "";
            int digit = new int();
            if (int.TryParse(digitStr, out digit)) {
                if (digit >= 0)
                {
                    arrayLength += 1;
                    int[] tmpArray = new int[arrayLength];
                    array.CopyTo(tmpArray, 0);
                    tmpArray[arrayLength - 1] = digit;
                    array = tmpArray;
                    message = "Значение " + digit + " добавлено в массив";
                }
                else
                {
                    message = "Значение должно быть положительным числом числом";
                }
            } else {
                message = "Значение не является числом";
            }
            return message; 
        }

        public String Delete(String indexStr)
        {
            //удаление по индексу
            String message = "";
            int index = new int();
            if (int.TryParse(indexStr, out index))
            {
                if ((index < arrayLength) && (index >= 0 ))
                {
                    arrayLength -= 1;
                    int[] tmpArray = new int[arrayLength];
                    for(int i = 0; i < index; i++)
                    {
                        tmpArray[i] = array[i];
                    }
                    for (int i = index; i < tmpArray.Length; i++)
                    {
                        tmpArray[i] = array[i + 1];
                    }
                    array = tmpArray;
                    message = "Значение по индексу " + index + " удалено из массива";
                }
                else
                {
                    message = "Введенное число не является индексом тиекущего массива";
                }
            }
            else
            {
                message = "Индекс не является числом";
            }
            return message;
        }
        
        public String GetArrayString()
        {
            String arrayStr = "";
            foreach (int numb in array) arrayStr += numb + " ";
            return arrayStr;
        }

        public void SortArray()
        {
            List<int> numbsToSort = new List<int>();
            for (int i = 0; i < array.Length; i++)
            {
                if (((array[i] % 2) == 0) && array[i] != 0)
                {
                    numbsToSort.Add(array[i]);
                    array[i] = -1;
                }
            }
            Comporator comporator = new Comporator();
            numbsToSort.Sort(comporator);
            int currentListIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == -1)
                {
                    array[i] = numbsToSort.ElementAt(currentListIndex);
                    currentListIndex++;
                }
            }
        }
    }
}
