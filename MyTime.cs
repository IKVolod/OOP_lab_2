using ООП_лаб_2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ООП_лаб_2
{
    public class MyTime
    {
        private int _hour;
        private int _minute;
        private int _second;

        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value is < 0 or > 24) throw new ArgumentException("Incorrect HOUR input");
                _hour = value == 24 ? 0 : value;
            }
        }
        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value is < 0 or >= 60) throw new ArgumentException("Incorrect MINUTE input");
                _minute = value;
            }
        }
        public int Second
        {
            get { return _second; }
            set
            {
                if (value is < 0 or >= 60) throw new ArgumentException("Incorrect SECOND input");
                _second = value;
            }
        }
        
        public MyTime(int h, int m, int s)
        {
            Hour = h;
            Minute = m;
            Second = s;
        }
        
        public override string ToString()
        {
            return $"{_hour}:{_minute:D2}:{_second:D2}";
        }

        public int TotalSeconds
        {
            get { return TimeSinceMidnight(); }
        }
        public int TimeSinceMidnight()
        {
            return _hour * 3600 + _minute * 60 + _second;
        }
        public static MyTime TimeSinceMidnight(int t)
        {
            t %= 86400;
            t = t < 0 ? t + 86400 : t;
            return new MyTime(t / 3600, (t / 60) % 60,t % 60);
        }
        public MyTime(int t)
        {
            SecondsToObject(t);
        }
        private void SecondsToObject(int t)
        {
            t %= 86400;
            t = t < 0 ? t + 86400 : t;
            Hour = t / 3600;
            Minute = (t / 60) % 60;
            Second = t % 60;
        }

        private bool AddOneSomething(ref int field, int additive)
        {
            bool wasOperation = false;
            if (field + 1 == additive)
            {
                field = 0;
                wasOperation = true;
            }
            else
            {
                field += 1;
            }
            return wasOperation;
        }
        public void AddOneSecond()
        {
            if (AddOneSomething(ref _second, 60))
            {
                if (AddOneSomething(ref _minute, 60))
                {
                    AddOneSomething(ref _hour, 24);
                }
            }
        }
        public void AddOneMinute()
        {
            if (AddOneSomething(ref _minute, 60))
            {
                AddOneSomething(ref _hour, 24);
            }
        }
        public void AddOneHour()
        {
            AddOneSomething(ref _hour, 24);
        }
        
        public void AddSeconds(int t)
        {
            SecondsToObject(TotalSeconds + t);
        }
        
        public int Difference(MyTime time)
        {
            return TotalSeconds - time.TotalSeconds;
        }

        public void WhatLesson(MyShedule shedule)
        {
            shedule.TestFillList();

            if (TotalSeconds < shedule.GetList[0].First().TotalSeconds)
            {
                Console.WriteLine("Пари ще не почалися");
            }
            else if (TotalSeconds >= shedule.GetList.Last().Last().TotalSeconds)
            {
                Console.WriteLine("Пари вже закінчилися");
            }
            else
            {
                for (int i = 0; i < shedule.GetList.Count; i++)
                {
                    if (shedule.GetList[i][0].TotalSeconds <= TotalSeconds &
                        TotalSeconds < shedule.GetList[i][1].TotalSeconds)
                    {
                        Console.WriteLine($"Зараз {i + 1} пара");
                        break;
                    }
                    else if (shedule.GetList[i][1].TotalSeconds <= TotalSeconds &
                             TotalSeconds < shedule.GetList[i + 1][0].TotalSeconds)
                    {
                        Console.WriteLine($"Зараз перерва між {i + 1} та {i + 2} парою");
                        break;
                    }
                }
            }
        }
    }
}
