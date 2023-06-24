import { Zarzad } from "src/app/Zarzad/Models/zarzad.model";

export interface Pracownik {
    IdPracownik: number;
    Imie: string;
    Nazwisko: string;
    PESEL: string;
    Wiek: number;
    WykonywanaFunkcja: string;
    Wynagrodzenie: number;
    IdZarzadu: Zarzad;
}

