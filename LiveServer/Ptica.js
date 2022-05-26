export class Ptica
{
constructor(id,naziv,urlSlike)
{
    this.id=id;
    this.naziv=naziv;
    this.urlSlike=urlSlike;
    this.kontejner=null;

}

crtajPticu(host,podrucje){

    var nadjiDivKojiPratiPojave=document.getElementsByClassName('kontZaPtice'+this.id);//querySelector('div[className=".kontZaPtice"]');
    console.log(nadjiDivKojiPratiPojave[0]);
    if (nadjiDivKojiPratiPojave[0]!=null){
    var nadjiDivKojiPratiPojaveParent=nadjiDivKojiPratiPojave[0].parentNode;
    nadjiDivKojiPratiPojaveParent.removeChild(nadjiDivKojiPratiPojave[0]);
    }

    var kontejnerZaPtice=document.createElement("div");
    kontejnerZaPtice.className="kontZaPtice"+this.id;
    host.appendChild(kontejnerZaPtice);

    kontejnerZaPtice.innerHTML=this.naziv+"      "+this.urlSlike+" -  ";

    var dugme=document.createElement("button");
    kontejnerZaPtice.appendChild(dugme);
    dugme.innerHTML="dodaj";

    dugme.onclick=(ev)=>{
        fetch("https://localhost:5001/Ispit/DodajPojavuPtice/"+this.id+"/"+podrucje,
        {
            method:"PUT",
        }).then(p=>
            {if(p.ok){
                        alert("Broj pojava je uvecan");//tu treba dodati da se vrati podatak o pojavama ptice
                      
                       /* var kontejnerZaPtice=document.createElement("div");
                        kontejnerZaPtice.className("kontZaPtice");
                        host.appendChild(kontejnerZaPtice);
                
                        kontejnerZaPtice.innerHTML=this.naziv;
                        kontejnerZaPtice.innerHTML=this.urlSlike;*/
                
                }
            });
        }
    }
}