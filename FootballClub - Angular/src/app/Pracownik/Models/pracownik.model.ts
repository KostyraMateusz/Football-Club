import { Zarzad } from "src/app/Zarzad/Models/zarzad.model";

export interface Pracownik {
    idPracownik: number;
    imie: string;
    nazwisko: string;
    pesel: string;
    wiek: number;
    wykonywanaFunkcja: string;
    wynagrodzenie: number;
    idZarzadu: string;
}

