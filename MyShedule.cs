using ООП_лаб_2;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ООП_лаб_2
{
    internal class MyTime_Array_Comparer : IComparer<MyTime>
    {
        public int Compare(MyTime x, MyTime y)
        {
            return (x.TotalSeconds).CompareTo(y.TotalSeconds);
        }
    }
    
    public class MyShedule
    {
        private List<MyTime[]> _shedule;

        public List<MyTime[]> GetList
        {
            get { return _shedule;  }
        }

        public void TestFillList()
        {
            _shedule.Add(new[] {new MyTime(8,0,0), new MyTime(9,20,0)});    //1 пара
            _shedule.Add(new[] {new MyTime(9,40,0), new MyTime(11,0,0)});   //2 пара
            _shedule.Add(new[] {new MyTime(11,20,0), new MyTime(12,40,0)}); //3 пара
            _shedule.Add(new[] {new MyTime(13,0,0), new MyTime(14,20,0)});  //4 пара
            _shedule.Add(new[] {new MyTime(14,40,0), new MyTime(16,0,0)});  //5 пара
            _shedule.Add(new[] {new MyTime(16,10,0), new MyTime(17,30,0)}); //6 пара
            _shedule.Add(new[] {new MyTime(17,40,0), new MyTime(19,0,0)});  //7 пара
        }

        public MyShedule()
        {
            _shedule = new List<MyTime[]>();
        }
        
        public MyShedule(MyTime[] arrayOfTimes)
        {
            Check_MyTime_Array_Size(arrayOfTimes);
            
            Array.Sort(arrayOfTimes, new MyTime_Array_Comparer());

            _shedule = new List<MyTime[]>();
            
            for (int i = 0; i < arrayOfTimes.Length / 2; i += 2)
            {
                _shedule.Add(new MyTime[]{arrayOfTimes[i], arrayOfTimes[i + 1]});
            }
        }

        private void Check_MyTime_Array_Size(MyTime[] arrayOfTimes)
        {
            if (arrayOfTimes.Length % 2 == 1) throw new ArgumentException("Array size must be even number");
        }
    }
}
