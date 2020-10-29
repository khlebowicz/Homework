using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Common
{
    public sealed class Invariants
    {
        public static readonly DateTime DefaultLastDate = new DateTime(9999, 1, 1);

        public sealed class Messages
        {
            public const string PerformanceMustBePlanned = "Występ musi być zaplanowany";
            public const string SeatNotBought = "Wskazane miejsce zostało wykupione";

            public const string PerformanceMustExists = "Błędny identyfikator występu";
            public const string PerformanceIdNotEmpty = "Brak identyfikatora występu";
        }
    }
}
