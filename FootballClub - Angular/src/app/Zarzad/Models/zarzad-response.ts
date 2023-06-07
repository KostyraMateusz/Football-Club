import { KlubResponse } from "src/app/Klub/Models/klub-response";
import { PracownikResponse } from "src/app/Pracownik/Models/pracownik-response";

export interface ZarzadResponse {
    IdZarzad: number;
    Pracownicy: PracownikResponse[];
    Budzet: number;
    Cele: string;
    IdKlubu: KlubResponse;
}