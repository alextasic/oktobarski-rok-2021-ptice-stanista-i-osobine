import {Osobina} from "./Osobina.js"
import { Podrucje } from "./Podrucje.js"
import { Ptica } from "./Ptica.js";

export class PretragaPtica{
    constructor(){

        this.kontejner=null;
    }

pretragaPtica(host) {
    
    var glavniDiv=document.createElement("div");
    host.appendChild(glavniDiv);

}
crtajDeoZaUnos(hst){

    this.kontejner=document.createElement("div");
    hst.appendChild(this.kontejner);

    var divZaUnos=document.createElement("div");
    divZaUnos.className="divZaUnos";
    this.kontejner.appendChild(divZaUnos);

    var divZaIzbor=document.createElement("div");
    divZaIzbor.className="divZaIzbor";
    divZaUnos.appendChild(divZaIzbor);

    var divZaIzbor=document.createElement("label");
    divZaIzbor.innerHTML="Izbor Podrucja";
    divZaUnos.appendChild(divZaIzbor);

    var divZaPrikaz=document.createElement("div");
    divZaPrikaz.className="divPrikaz";
   /* divZaPrikaz.innerHTML="Prikaz ptica";*/
    hst.appendChild(divZaPrikaz);

   

    let selekt=document.createElement("select");
    selekt.name="selekt";
    divZaUnos.appendChild(selekt);

    fetch("https://localhost:5001/Ispit/PreuzmiPodrucja",
        {
            method:"GET",
        }).then(p=>p.json().then(data=>{
            data.forEach(element => {

            var opcija=document.createElement("option");
           
            opcija.innerHTML=element.naziv;
            opcija.value=element.id;
            console.log(element.id);
            selekt.appendChild(opcija);
            });
        })
    )

    var divZaIzborOsobina=document.createElement("div");
    divZaIzborOsobina.className="divZaIzborOsobina";
    divZaUnos.appendChild(divZaIzborOsobina);

    divZaUnos.appendChild(divZaIzborOsobina);


    var divZaIzborOsobina1=document.createElement("div");
    divZaIzborOsobina.className="divZaIzborOsobina1";
    divZaUnos.appendChild(divZaIzborOsobina1);

    divZaUnos.appendChild(divZaIzborOsobina1);

    var divZaIzborOsobina2=document.createElement("div");
    divZaIzborOsobina2.className="divZaIzborOsobina2";
    divZaUnos.appendChild(divZaIzborOsobina2);

    divZaUnos.appendChild(divZaIzborOsobina2);

    var nizPojavaOsobina=[];///definicija niza
    var j=0;

    fetch("https://localhost:5001/Ispit/PreuzmiOsobine",
    {
        method:"GET",
    }).then(p=>p.json().then(data=>{
        data.forEach(element => {

       if ((nizPojavaOsobina.find( o=> o==element.naziv))==undefined){///ako ga ne nadje
            nizPojavaOsobina.push(element.naziv);
    

            var divZaIzborOsobinai=document.createElement("div");
            divZaIzborOsobinai.className=element.naziv;
            divZaIzborOsobina.appendChild(divZaIzborOsobinai);

            var tekstNaziv=document.createElement("label");
            tekstNaziv.innerHTML=element.naziv;
            divZaIzborOsobinai.appendChild(tekstNaziv);

                var opcija=document.createElement("input");
                opcija.type="radio";
                opcija.name=element.naziv;
                opcija.value=element.id;
                divZaIzborOsobinai.appendChild(opcija);

                var tekst=document.createElement("label");
                tekst.innerHTML=element.vrednost1;
                divZaIzborOsobinai.appendChild(tekst);

        
////////////////////////////////////////////////////////generalno osobina ima naziv i vrednost, ako se vidi da dve osobine imaju isti naziv, onda
////////////////////////////////////////////////////////se dodaju istoj grupi osobina
        }
        else{

        var nadjeniDiv= document.createElement("div");
        nadjeniDiv = document.getElementsByClassName(element.naziv)[0]; //ako ga nadje treba samo da doda novi radio element 
                                                                        //[0] sluzi da nadje 1 element

                var opcija=document.createElement("input");
                opcija.type="radio";
                opcija.name=element.naziv;
                opcija.value=element.id;
                nadjeniDiv.appendChild(opcija);

                var tekst=document.createElement("label");
                tekst.innerHTML=element.vrednost1;
                nadjeniDiv.appendChild(tekst);

        }
       }
    )}))
        var dugme=document.createElement("button");
        dugme.innerHTML="Pronadji";
        divZaIzbor.appendChild(dugme);


    dugme.onclick=(ev)=>{/////PROSLEDJIVANJE SELEKTOVANIH OSOBINA I PODRUCJA
        

        let selektovani=this.kontejner.querySelectorAll('input[type="radio"]:checked');

        let NizSelektovanih="";

        for(let i=0;i<selektovani.length;i++)
        {
            NizSelektovanih = NizSelektovanih.concat(selektovani[i].value,"a");
        }
                                                    
        var izabranoPodrucje=this.kontejner.querySelector("select[name=selekt]").value;
 
        console.log(NizSelektovanih);

        fetch("https://localhost:5001/Ispit/TrazenjePtica/"+ NizSelektovanih + "/" + izabranoPodrucje , {
            method:"GET",
            ///ne sme get da ima body

        }).then(p=>p.json().then(data=>{
            data.forEach(element => {
                
            var divZaPrikaz3=document.createElement("div");
            divZaPrikaz.className="divPrikaz3";
            divZaPrikaz.appendChild(divZaPrikaz3);
            var pticaa=new Ptica(element.id,element.naziv,element.URLSlike);
            pticaa.crtajPticu(divZaPrikaz3,izabranoPodrucje);
            
            })
        }))
    }
}
crtajDeoZaPrikaz(hst)
{
    var divZaPrikaz=document.createElement("div");
    divZaPrikaz.className="divPrikaz";
    hst.appendChild(divZaPrikaz);  
}
}
