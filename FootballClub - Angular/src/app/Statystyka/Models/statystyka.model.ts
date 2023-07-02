import { Pilkarz } from "src/app/Pilkarz/Models/pilkarz.model";

export interface Statystyka {
    IdStatystyka: number;
    Mecz: string;
    Gole: number;
    Asysty: number;
    ZolteKartki: number;
    CzerwoneKartki: number;
    PrzebiegnietyDystans: number;
    Ocena: number;
    IdPilkarz: Pilkarz;
}
