import { KlubResponse } from "src/app/Klub/Models/klub-response";
import { StatystykaResponse } from "src/app/Statystyka/Models/statystyka-response";

export interface PilkarzResponse {
    IdPilkarz: number;
    Imie: string;
    Nazwisko: string;
    Wiek: number;
    Pozycja: string;
    Statystyki: StatystykaResponse[];
    ArchiwalneKluby: KlubResponse[];
    Wynagrodzenie: number;
    IdKlubu: KlubResponse;
}