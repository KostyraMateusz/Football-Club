import { Pilkarz } from "src/app/Pilkarz/Models/pilkarz.model";
import { Zarzad } from "src/app/Zarzad/Models/zarzad.model";

export interface Klub {
    idKlub: number;
    nazwa: string;
    stadion: string;
    trofea: string;
    archiwalniPilkarze: Pilkarz[];
    obecniPilkarze: Pilkarz[];
    zarzad: Zarzad;
}
