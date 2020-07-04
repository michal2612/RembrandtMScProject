using System;

namespace Rembrandt.Users.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToTimestamp(this DateTime dateTime, DateTime date)
        {
            var epoch = new DateTime(1970,1,1,0,0,0, DateTimeKind.Utc);
            var time = date.Subtract(new TimeSpan(epoch.Ticks));

            return time.Ticks / 10000000 ;
        }
    }
}