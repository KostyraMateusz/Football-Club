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
##### Usuń piłkarza z obecnych pilkarzy klubu
```http
POST /api/Kluby/UsunPilkarzaZObecnych
```

<br>

## Pilkarze
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
##### Daj statystykę najdłuższego przebiegniętego dystansu
```http
GET /api/Statystyki/DajStatystykeNajdluzszePrzebiegnieteDystanse
```

<br>

## Zarzady
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
