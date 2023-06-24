import { Klub } from "src/app/Klub/Models/klub.model";
import { Pracownik } from "src/app/Pracownik/Models/pracownik.model";

export interface Zarzad {
    idZarzad: number;
    pracownicy: Pracownik[];
    budzet: number;
    cele: string;
    idKlubu: Klub;
}