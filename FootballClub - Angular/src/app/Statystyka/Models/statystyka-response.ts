import { PilkarzResponse } from "src/app/Pilkarz/Models/pilkarz-response";

export interface StatystykaResponse {
    IdStatystyka: number;
    Mecz: string;
    Gole: number;
    Asysty: number;
    ZolteKartki: number;
    CzerwoneKartki: number;
    PrzebiegnietyDystans: number;
    Ocena: number;
    IdPilkarz: PilkarzResponse;
}