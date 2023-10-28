using ООП_лаб_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

class Program
{
    static void Main()
    {
        while (true)
        {
            MyTime obj = Make_Object_MyTime();
            obj.WhatLesson();
        }

        while (true)
        {
            MyTime time = new MyTime(2, 30, 0);
            Console.WriteLine(time);
            time.AddSeconds(int.Parse(Console.ReadLine()));
            Console.WriteLine(time);
            Console.WriteLine("==================================");
        }
    }

    static MyTime Make_Object_MyTime()
    {
        Console.WriteLine("Напишіть ваш час через пробіл (лише цілі числа)");
        int[] array = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        return new MyTime(array[0], array[1], array[2]);
    }
}