using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        //Задание 1
        static void Task1()
        {
            Stack<int> stack = new Stack<int>();
            uint n;
            Console.WriteLine("Введите число N");
            
            while (!UInt32.TryParse(Console.ReadLine(), out n))
                Console.WriteLine("Неверный формат ввода, введите число");

            for (int i = 1; i <= n; i++)
                stack.Push(i);

            GetInfo(stack);

            if (stack.Count != 0)
            {
                Console.WriteLine("Извлечение из стека");
                stack.Pop();

                GetInfo(stack);

                Console.WriteLine("Очистка стека");
                stack.Clear();

                GetInfo(stack);
            }
        }
        static void PrintStack(Stack<int> stack)
        {
            foreach (var i in stack)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
        static void GetInfo(Stack<int> stack)
        {
            Console.WriteLine("Содержимое стека");
            PrintStack(stack);
            Console.WriteLine($"Размерность стека {stack.Count}");
            if (stack.Count!=0)
                Console.WriteLine($"Верхний элемент стека {stack.Peek()}\n");
        }

        //Задание 2.1
        static void Task21()//((x-12)*((m+67)+12))*(5-i)=(12/(k+34))
        {
            string path = "t.txt";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                Stack<int> bracket = new Stack<int>();
                int index = -1;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == '(')
                        bracket.Push(i);
                    else if (text[i] == ')' && bracket.Count != 0)
                        bracket.Pop();
                    else if (text[i] == ')' && bracket.Count == 0)
                    {
                        index = i;
                        break;
                    }
                }

                if (bracket.Count == 0 && index == -1)
                    Console.WriteLine("Cкобки сбалансированы");
                else if (index != -1) Console.WriteLine($"Возможно лишняя ) на позиции {index + 1}");
                else Console.WriteLine($"Возможно лишняя ( на позиции {bracket.Peek() + 1}");
            }
        }

        //Задание2.2
        static void Task22()
        {
            string path = "t.txt";
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
                bool falseBrackets = true;

                while (falseBrackets)
                {
                    Stack<int> bracket = new Stack<int>();
                    int index = -1;
                    for (int i = 0; i < text.Length; i++)
                    {
                        if (text[i] == '(')
                            bracket.Push(i);
                        else if (text[i] == ')' && bracket.Count != 0)
                            bracket.Pop();
                        else if (text[i] == ')' && bracket.Count == 0)
                        {
                            index = i;
                            break;
                        }
                    }
                    if (bracket.Count == 0 && index == -1)
                        falseBrackets = false;
                    else if (index != -1) text = text.Remove(index, 1);
                    else text = text.Remove(bracket.Peek(), 1);
                }

                File.WriteAllText("t1.txt", text);
            }
        }

        //Основная программа
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания\nПервое\t\t1\nВторое(а)\t2\nВторое(б)\t3");
            switch(Console.ReadLine())
            {
                case "1":
                    //Задание 1
                    Task1();
                    break;
                case "2":
                    //Задание 2.1
                    Task21();
                    break;
                case "3":
                    //Задание 2.2
                    Task22();
                    break;
                default:
                    Console.WriteLine("Ввод неверен");
                    break;
            }
        Console.ReadKey();
        }
    }
}
