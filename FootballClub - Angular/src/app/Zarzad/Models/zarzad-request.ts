import { KlubResponse } from "src/app/Klub/Models/klub-response";
import { PracownikResponse } from "src/app/Pracownik/Models/pracownik-response";

export class ZarzadRequest {
    Pracownicy: PracownikResponse[];
    Budzet: number;
    Cele: string;
    IdKlubu: KlubResponse;

    constructor(Pracownicy: PracownikResponse[], Budzet: number, Cele: string, IdKlubu: KlubResponse) {
       this.Pracownicy = Pracownicy;
       this. Budzet = Budzet;
       this.Cele = Cele;
       this.IdKlubu = IdKlubu;
    }
}