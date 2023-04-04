using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Stack__Deque__Queue
{
    class Stack  //LIFO
    {
        int[] arr_stack = new int[0];
        
        public void Push(int num)  //додаємо елемент
        {
            Array.Resize(ref arr_stack, arr_stack.Length + 1);
            arr_stack[arr_stack.Length - 1] = num;
        }
        public int Pop()  //видаляємо та повертаємо елемент
        {
            int remove_elem = arr_stack[arr_stack.Length - 1];
            Array.Resize(ref arr_stack, arr_stack.Length - 1);
            return remove_elem;
        }
        public int Peek()  //повертаємо елемент без видалення
        {
            int elem = arr_stack[arr_stack.Length - 1];
            return elem;
        }
        public int Count()  //повертаємо к-сть елементів
        {
            int count = arr_stack.Length;
            return count;
        }
        public void Clear()  //видаляємо елементи
        {
            Array.Resize(ref arr_stack, 0);
        }
    }

    class Queue   //FIFO
    {
        int[] arr_queue = new int[0];

        public void Enqueue(int num)  //додаємо елемент
        {
            Array.Resize(ref arr_queue, arr_queue.Length + 1);
            arr_queue[arr_queue.Length - 1] = num;
        }
        public int Dequeue()  //видаляємо та повертаємо елемент
        {
            int remove_elem = arr_queue[0];
            int[] new_arr = new int[arr_queue.Length];

            for(int i = 0; i < arr_queue.Length; i++)
            {
                if (i == arr_queue.Length - 1)
                {
                    new_arr[i] = arr_queue[0];
                    break;
                }
                new_arr[i] = arr_queue[i+1];
            }
            Array.Copy(new_arr, arr_queue, arr_queue.Length - 1);
            Array.Resize(ref arr_queue, arr_queue.Length - 1);
            return remove_elem;
        }
        public int Peek()  //повертаємо елемент без видалення
        {
            int elem = arr_queue[0];
            return elem;
        }
        public int Count()  //повертаємо к-сть елементів
        {
            int count = arr_queue.Length;
            return count;
        }
        public void Clear()  //видаляємо елементи
        {
            Array.Resize(ref arr_queue, 0);
        }
    }

    class Deque
    {
        int[] arr_deque = new int[0];
        public void AddFirst(int num)
        {
            int[] new_arr = new int[arr_deque.Length+1];
            new_arr[0] = num;

            for (int i = 1; i < arr_deque.Length; i++)
            {
                new_arr[i] = arr_deque[i-1];
            }
            Array.Resize(ref arr_deque, arr_deque.Length + 1);
            Array.Copy(new_arr, arr_deque, arr_deque.Length);
        }
        public void AddLast(int num)
        {
            Array.Resize(ref arr_deque, arr_deque.Length + 1);
            arr_deque[arr_deque.Length - 1] = num;
        }
        public int RemoveFirst()
        {
            int remove_elem = arr_deque[0];
            int[] new_arr = new int[arr_deque.Length];

            for (int i = 0; i < arr_deque.Length; i++)
            {
                if (i == arr_deque.Length - 1)
                {
                    new_arr[i] = arr_deque[0];
                    break;
                }
                new_arr[i] = arr_deque[i + 1];
            }
            Array.Copy(new_arr, arr_deque, arr_deque.Length - 1);
            Array.Resize(ref arr_deque, arr_deque.Length - 1);
            return remove_elem;
        }
        public int RemoveLast()
        {
            int remove_elem = arr_deque[arr_deque.Length - 1];
            Array.Resize(ref arr_deque, arr_deque.Length - 1);
            return remove_elem;
        }
        public bool Contains(int num)
        {
            for(int i = 0; i < arr_deque.Length; i++)
            {
                if (arr_deque[i] == num)
                {
                    return true;
                }
            }
            return false;
        }
        public int Count()  //повертаємо к-сть елементів
        {
            int count = arr_deque.Length;
            return count;
        }
        public void Clear()  //видаляємо елементи
        {
            Array.Resize(ref arr_deque, 0);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack stack1 = new Stack();
            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack1.Push(4);
            Console.WriteLine($"count of elements = {stack1.Count()}");
            stack1.Pop();
            Console.WriteLine($"return first element after method Pop() = {stack1.Peek()}");
            stack1.Clear();
            Console.WriteLine($"count of elements after method Clear() = {stack1.Count()}");
            Console.WriteLine();

            Queue queue1 = new Queue();
            queue1.Enqueue(4);
            queue1.Enqueue(5);
            queue1.Enqueue(6);
            queue1.Enqueue(7);
            Console.WriteLine($"count of elements = {queue1.Count()}");
            queue1.Dequeue();
            Console.WriteLine($"return first element after method Dequeue() = {queue1.Peek()}");
            Console.WriteLine($"count of elements = {queue1.Count()}");
            Console.WriteLine();

            Deque deque1 = new Deque(); // [ 3, 2, 1, 10, 11, 12]
            deque1.AddFirst(1);
            deque1.AddFirst(2);
            deque1.AddFirst(3);
            deque1.AddLast(10);
            deque1.AddLast(11);
            deque1.AddLast(12);
            Console.WriteLine($"count of elements = {deque1.Count()}");
            Console.WriteLine(deque1.RemoveLast());
            Console.WriteLine(deque1.RemoveFirst());
            Console.WriteLine($"count of elements = {deque1.Count()}");
            Console.WriteLine(deque1.Contains(10));
            Console.WriteLine(deque1.Contains(3));
            Console.WriteLine(deque1.Contains(12));

            Console.ReadKey();
            
        }
    }
}
