import { ZarzadResponse } from "src/app/Zarzad/Models/zarzad-response";

export interface PracownikResponse {
    IdPracownik: number;
    Imie: string;
    Nazwisko: string;
    PESEL: string;
    Wiek: number;
    WykonywanaFunkcja: string;
    Wynagrodzenie: number;
    IdZarzadu: ZarzadResponse;
}