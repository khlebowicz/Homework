using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Common
{
    public sealed class Invariants
    {
        public static readonly DateTime DefaultSaleDate = new DateTime(9999, 1, 1);
        public const int ReservationLengthForRegularUser = 10;
        public const int ReservationLengthForVIPUser = 60;

        public sealed class Messages
        {
            public const string PerformanceMustBePlanned = "Występ musi być zaplanowany";
            public const string BoughtSeat = "Wskazane miejsce zostało wykupione";
            public const string ReservedSeat = "Wskazane miejsce zostało zarezerwowane";
    
            public const string UserMustExists = "Błędny identyfikator użytkownika";
            public const string ReservationMustExists = "Błędny identyfikator rezerwacji";
            public const string ReservationMustBeActive = "Wskazna rezerwacja straciła ważność";
            

            public const string PerformanceMustExists = "Błędny identyfikator występu";
            public const string PerformanceIdNotEmpty = "Brak identyfikatora występu";
        }
    }
}
