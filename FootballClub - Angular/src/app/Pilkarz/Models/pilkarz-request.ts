import { KlubResponse } from "src/app/Klub/Models/klub-response";
import { StatystykaResponse } from "src/app/Statystyka/Models/statystyka-response";

export class PilkarzRequest {
    Imie: string;
    Nazwisko: string;
    Wiek: number;
    Pozycja: string;
    Statystyki: StatystykaResponse[];
    ArchiwalneKluby: KlubResponse[];
    Wynagrodzenie: number;
    IdKlubu: KlubResponse;

    constructor(Imie: string, Nazwisko: string, Wiek: number, Pozycja: string, Statystyki: StatystykaResponse[], ArchiwalneKluby: KlubResponse[], Wynagrodzenie: number,IdKlubu: KlubResponse) {
       this.Imie = Imie;
       this.Nazwisko = Nazwisko;
       this.Wiek = Wiek;
       this.Pozycja = Pozycja;
       this.Statystyki = Statystyki;
       this.ArchiwalneKluby = ArchiwalneKluby;
       this.Wynagrodzenie = Wynagrodzenie;
       this.IdKlubu = IdKlubu;
    }
}