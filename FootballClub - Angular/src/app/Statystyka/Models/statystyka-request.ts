import { PilkarzResponse } from "src/app/Pilkarz/Models/pilkarz-response";

export class StatystykaRequest {
    Mecz: string;
    Gole: number;
    Asysty: number;
    ZolteKartki: number;
    CzerwoneKartki: number;
    PrzebiegnietyDystans: number;
    Ocena: number;
    IdPilkarz: PilkarzResponse;

    constructor(Mecz: string, Gole: number, Asysty: number, ZolteKartki: number, CzerwoneKartki: number, PrzebiegnietyDystans: number, Ocena: number, IdPilkarz: PilkarzResponse) {
        this.Mecz = Mecz;
        this. Gole = Gole;
        this.Asysty = Asysty;
        this.ZolteKartki = ZolteKartki;
        this.CzerwoneKartki = CzerwoneKartki;
        this.PrzebiegnietyDystans = PrzebiegnietyDystans;
        this.Ocena = Ocena;
        this.IdPilkarz = IdPilkarz;
    }
}