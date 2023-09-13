# Football-Club
Celem niniejszego projektu jest stworzenie aplikacji webowej dla klubu piłkarskiego, która umożliwi łatwy dostęp do różnorodnych informacji dotyczących klubu – obecnego zarządu oraz pracowników odpowiedzialnych za poprawne funkcjonowanie klubu, celów postawionych przez klub na aktualny sezon piłkarski oraz jego aktualnych oraz byłych piłkarzy.

Aplikacja ta będzie stanowić źródło informacji dla kibiców klubu oraz osób zainteresowanych historią klubu. Dzięki stworzeniu takiej aplikacji, fani będą mieli możliwość przeglądania aktualnych wyników meczów, statystyk piłkarzy, a także możliwość poznania historii klubu i jego wcześniejszych osiągnięć. Aplikacja będzie łatwo dostępna z poziomu przeglądarki internetowej oraz zaprojektowana w sposób intuicyjny i przyjazny dla użytkownika.

## Authors
* @KostyraMateusz
* @StanislawKluczewski

<br>

# Used Technologies:
- ASP .NET CORE 6.0(Long Time Support)
- Microsoft SQL Server 2022

<br>

# WEB API
## Kluby 
##### Utwórz klub
```http
POST api/Kluby/DodajKlub
```
##### Usuń klub
```http
DELETE api/Kluby/UsunKlub
```
##### Edytuj klub
```http
PUT api/Kluby/EdytujKlub
```
##### Daj kluby
```http
GET api/[controller]/DajKluby
```
##### Daj klub
```http
GET api/[controller]/DajKlub
```
##### Daj trofea klubu
```http
POST /api/Kluby/DajTrofeaKlubu
```
##### Daj stadion klubu
```http
POST /api/Kluby/DajStadionKlubu
```
##### Daj archiwalnego piłkarza
```http
GET /api/Kluby/DajArchiwalnegoPilkarza
```
##### Daj archiwalnych piłkarzy
```http
GET /api/Kluby/DajArchiwalnychPilkarzy
```
##### Daj obecnego piłkarza
```http
GET /api/Kluby/DajObecnegoPilkarza
```
##### Daj obecnych piłkarzy
```http
GET /api/Kluby/DajObecnegoPilkarza
```
##### Dodaj piłkarza do obecnych pilkarzy klubu
```http
POST /api/Kluby/DodajPilkarzaDoObecnych
```
##### Usuń pilkarza z obecnych
```http
POST /api/Kluby/UsunPilkarzaZObecnych
```
##### Dodaj piłkarza do archiwalnych
```http
POST /api/Kluby/DodajPilkarzaDoArchiwalnych
```

<br>

## Pilkarze
##### Utworz pilkarza
```http
POST api/Pilkarze/DodajPilkarza
```
##### Usuń pilkarza
```http
DELETE api/Pilkarze/UsunPilkarza
```
##### Edytuj pilkarza
```http
PUT api/Pilkarze/EdytujPilkarza
```
##### Daj pilkarzy
```http
GET /api/Pilkarze/DajPilkarzy
```
##### Daj pilkarza
```http
GET /api/Pilkarze/DajPilkarza
```
##### Daj archiwalne kluby piłkarza
```http
GET /api/Pilkarze/DajArchiwalneKlubyPilkarza
```
##### Daj statystyke piłkarza
```http
GET /api/Pilkarze/DajStatystykePilkarza
```
##### Daj statystyki piłkarza
```http
GET /api/Pilkarze/DajStatystykiPilkarza
```
##### Daj najlepsze statystyki piłkarza
```http
GET /api/Pilkarze/DajNajlepszeStatystykiPilkarza
```
##### Daj piłkarzy bez klubu
```http
GET /api/Pilkarze/DajPilkarzyBezKlubu
```
##### Zmień pozycje piłkarzy
```http
PUT /api/Pilkarze/ZmienPozycjePilkarza
```

<br>

## Pracownicy
##### Utworz pracownika
```http
POST api/Pracownicy/DodajPracownika
```
##### Usuń pracownika
```http
DELETE api/Pracownicy/UsunPracownika
```
##### Edytuj pracownika
```http
PUT api/Pracownicy/EdytujPracownika
```
##### Daj pracownikow
```http
GET api/Pracownicy/DajPracownikow
```
##### Daj pracownika
```http
GET api/Pracownicy/DajPracownika
```
##### Zmień funkcje pracownika
```http
PUT /api/Pracownicy/ZmienFunkcjePracownika
```
##### Zmień wynagrodzenie pracownika
```http
PUT /api/Pracownicy/ZmienWynagrodzenie
```
##### Zmień wiek pracownika
```http
PUT /api/Pracownicy/ZmienWiekPracownika
```

<br>

## Statystyki
##### Utworz statystykę
```http
POST api/Statystyki/DodajStatystke
```
##### Usuń statystykę
```http
DELETE api/Statystyki/UsunStatystyke
```
##### Edytuj statystykę
```http
PUT api/Statystyki/EdytujStatystyke
```
##### Daj statystyki
```http
GET api/Statystyki/DajStatystyki
```
##### Daj statystykę
```http
GET api/Statystyki/DajStatystyke
```
##### Daj statystykę meczu
```http
GET /api/Statystyki/DajStatystykeMeczu
```
##### Daj statystyki żółtych kartek
```http
GET /api/Statystyki/DajStatystkiZoltejKartki
```
##### Daj statystyki czerwonych kartek
```http
GET /api/Statystyki/DajStatystykiCzerwonychKartek
```
##### Daj statystykę najlepszej oceny
```http
GET /api/Statystyki/DajStatystykiNajlepszaOcena
```

<br>

## Zarzady
##### Daj zarządy
```http
GET api/Zarzady/DajZarzady
```
##### Daj wynik finansowy
```http
GET /api/Zarzady/DajWynikFinansowy
```
##### Dodaj cel do zarządu
```http
POST /api/Zarzady/DodajCelZarzadu
```
##### Dodaj członka zarządu
```http
POST /api/Zarzady/DodajCzlonkaZarzadu
```
##### Zmień budżet zarządu
```http
PUT /api/Zarzady/ZmienBudzetZarzadu
```
