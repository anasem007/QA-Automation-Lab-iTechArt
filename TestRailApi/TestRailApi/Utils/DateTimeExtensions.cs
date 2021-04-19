using System;

namespace TestRailApi.Utils
{
    public static class DateTimeExtensions
    {
        public static double ToUnixTimestamp(this DateTime dt)
        {
            return dt.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        }
        
        public static DateTime FromUnixTimeStamp(double timestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(timestamp).ToLocalTime();
        }
    }
}