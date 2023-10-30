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
            MyShedule shedule = new MyShedule();
            Console.WriteLine(obj.WhatLesson(shedule));
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
        Console.WriteLine("Напишiть ваш час через пробiл (лише цiлi числа)");
        int[] array = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        return new MyTime(array[0], array[1], array[2]);
    }
}