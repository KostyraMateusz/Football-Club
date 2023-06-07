import { ZarzadResponse } from "src/app/Zarzad/Models/zarzad-response";

export class KlubRequest {
    Nazwa: string;
    Stadion: string;
    Trofea: string;
    ArchwilaniPilkarze: string[];
    ObecniPilkarze: string[];
    Zarzad: ZarzadResponse;

    constructor(Nazwa: string, Stadion: string, Trofea: string, ArchwilaniPilkarze: string[], ObecniPilkarze: string[], Zarzad: ZarzadResponse) {
       this.Nazwa = Nazwa;
       this.Stadion = Stadion;
       this.Trofea = Trofea;
       this.ArchwilaniPilkarze = ArchwilaniPilkarze;
       this.ObecniPilkarze = ObecniPilkarze;
       this.Zarzad = Zarzad;
    }
}