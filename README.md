# Zadanie rekrutacyjne
Aplikacja służy do rezerwacji oraz kupowania biletów w teatrze.  
Chcielibyśmy abyś spróbował zrobić poniższe zadania według jak **najlepszych praktyk programowania**.  
Wykorzystaj do tego **REST API**.  
Od nas dostajesz projekt z początkowymi danymi.  
Jeżeli zadanie sprawiło Ci trudności to pokaż nam to co udało się zrobić.  
Rozwiązanie zadania wrzuć do **swojego repozytorium** i wyślij nam link.

### Struktura danych:
    Performance - występ, który ma listę miejsc.
    Seat - miejsce, które ma listę rezerwacji. Może być ich kilka. Niektóre rezerwacje nie są wykupowane i wygasają. 
    Rezerwacja - 
	    aktywna rezerwacja - dzisiejsza data mniejsza od daty rezerwacji, 
	    wykupiona rezerwacja - data 9999-01-01

### Zadania:
1. Pobierz informacje o występach - nazwa, data.
2. Pobierz listę dostępnych miejsc na dany występ.
3. Dodaj rezerwacje na miejsce w występie
	- występ musi być zaplanowany
	- miejsce nie może być wykupione
	- VIP ma możliwość zarezerwowania miejsca, gdzie jest aktywna rezerwacja zwykłego użytkownika
	- dla użytkownika VIP rezerwacja biletu jest aktywna 60min, dla zwykłego 10min
4. Wykup miejscówkę
	- rezerwacja musi być aktywna
	- miejsce musi być zarezerwowane przez tego samego użytkownika