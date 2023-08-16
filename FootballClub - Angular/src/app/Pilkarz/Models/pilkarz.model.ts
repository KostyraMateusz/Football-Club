import { Klub } from "src/app/Klub/Models/klub.model";
import { Statystyka } from "src/app/Statystyka/Models/statystyka.model";

export interface Pilkarz {
    idPilkarz: number;
    imie: string;
    nazwisko: string;
    wiek: number;
    pozycja: string;
    statystyki: Statystyka[];
    archiwalneKluby: Klub[];
    wynagrodzenie: number;
    idKlub: string;
}