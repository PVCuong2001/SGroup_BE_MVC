using System;

namespace Test1.Extention
{
    public static class ConstParameter
    {
        public static readonly TimeSpan duration = new TimeSpan(0,0,5,0); 
        public static readonly TimeSpan requiredActiveTime = new TimeSpan(0, 0, 1, 0);
    }
}