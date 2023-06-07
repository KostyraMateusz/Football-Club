import { ZarzadResponse } from "src/app/Zarzad/Models/zarzad-response";

export class PracownikRequest {
    Imie: string;
    Nazwisko: string;
    PESEL: string;
    Wiek: number;
    WykonywanaFunkcja: string;
    Wynagrodzenie: number;
    IdZarzadu: ZarzadResponse;

    constructor(Imie: string, Nazwisko: string, PESEL: string, Wiek: number, WykonywanaFunkcja: string, Wynagrodzenie: number, IdZarzadu: ZarzadResponse) {
       this.Imie = Imie;
       this.Nazwisko = Nazwisko;
       this.PESEL = PESEL;
       this.Wiek = Wiek;
       this.WykonywanaFunkcja = WykonywanaFunkcja;
       this.Wynagrodzenie = Wynagrodzenie;
       this.IdZarzadu = IdZarzadu;
    }
}