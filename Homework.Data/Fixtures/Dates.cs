using System;

namespace Homework.Data.Fixtures
{
    public static class Dates
    {
        private static readonly DateTime[] _dates = new DateTime[]
        {
            new DateTime(9999,01,01),
            new DateTime(2020,01,01,20,33,22),
            DateTime.Now.AddMinutes(15),
            DateTime.Now.AddDays(30)
        };

        public static DateTime Get(int index) => _dates[index];
    }
}
