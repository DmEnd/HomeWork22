using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        public static int[] GetArray(object a)
        {
            int n = (int)a;
            Random random = new Random();
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(0,100);
                Console.Write($"{array[i],4}");
            }
            Console.WriteLine();
            return array;
        }
        public static void SumArray(Task<int[]> task)
        {
            int [] arr = task.Result;
            int sum = 0;
            foreach (int c in arr)
            {
                sum += c;
            }
            Console.WriteLine($"Cумма элементов массива равна={sum}");
        }
        public static void MaxArray(Task<int[]> task)
        {
            int[] arr=task.Result;
            int max = arr[0];
            foreach (int c in arr)
            {
                if (max<c)
                {
                    max = c;
                }
            }
            Console.WriteLine($"Наибольшее число в массиве={max}");
        }


        static void Main(string[] args)
        {
             /*1.    Сформировать массив случайных целых чисел (размер  задается пользователем).
             * Вычислить сумму чисел массива и максимальное число в массиве.  
             * Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.
             */

            Console.Write("Введите размерность массива=");
            int  n= Convert.ToInt32(Console.ReadLine());

            Func<object,int[]> func1 =new Func<object, int[]>(GetArray);
            Task <int[]> task1 = new Task <int []> (func1,n);

            Action<Task<int[]>> action1=new Action<Task<int[]>>(SumArray);
            Task  task2= task1.ContinueWith(action1);

            Action<Task<int[]>> action2 = new Action<Task<int[]>>(MaxArray);
            Task task3 = task1.ContinueWith(action2);

            task1.Start();
            Console.ReadKey();
        }
    }
}
