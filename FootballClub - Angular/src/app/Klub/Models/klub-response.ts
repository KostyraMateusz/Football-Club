import { ZarzadResponse } from "src/app/Zarzad/Models/zarzad-response";

export interface KlubResponse {
    IdKlub: number;
    Nazwa: string;
    Stadion: string;
    Trofea: string;
    ArchwilaniPilkarze: string[];
    ObecniPilkarze: string[];
    Zarzad: ZarzadResponse;
}