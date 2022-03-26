import {Osobina} from "./Osobina.js"
import { Podrucje } from "./Podrucje.js"
import {PretragaPtica} from "./crtanje.js"

var mainDiv=document.createElement("div");
mainDiv.className="glavniDiv";
document.body.appendChild(mainDiv);

    var e=new PretragaPtica();
    e.crtajDeoZaUnos(mainDiv);
    
/*
trebalo bi da napravis prvo polje za ucitavanje iz baze podrucja
nakon toga bi trebalo da napravis polja za ucitavanje osobina i da imas radiobuttone gde biras
onda treba da napravis elemente na desnoj strani gde ucitavas iz baze ono sto je potrebno da prikazes
on click ce to biti. uglavnom su get metode, samo imas post metodu kada u bazi pamtis novo pojavljivanje
*/