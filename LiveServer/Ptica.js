export class Ptica
{
constructor(id,naziv,URLSlike)
{
    this.id=id;
    this.naziv=naziv;
    this.URLSlike=URLSlike;
    this.kontejner=null;

}

crtajPticu(host,podrucje){

    var kontejnerZaPtice=document.createElement("div");
    kontejnerZaPtice.className="kontZaPtice";
    host.appendChild(kontejnerZaPtice);

    kontejnerZaPtice.innerHTML=this.naziv+"  "+this.URLSlike;
    


    var dugme=document.createElement("button");
    kontejnerZaPtice.appendChild(dugme);
    dugme.innerHTML="dodaj";

    dugme.onclick=(ev)=>{
        fetch("https://localhost:5001/Ispit/DodajPojavuPtice/"+this.id+"/"+podrucje,
        {
            method:"PUT",
        }).then(p=>
            {if(p.ok){
                
                    

                        alert("Broj pojava je uvecan");
                       /* var nadjiDivKojiPratiPojave=this.kontejner.querySelector("div[className=kontZaPtice]");
                        var nadjiDivKojiPratiPojaveParent=nadjiDivKojiPratiPojave.parentNode
                        nadjiDivKojiPratiPojaveParent.removeChild(nadjiDivKojiPratiPojave);

                        var kontejnerZaPtice=document.createElement("div");
                        kontejnerZaPtice.className("kontZaPtice");
                        host.appendChild(kontejnerZaPtice);
                
                        kontejnerZaPtice.innerHTML=this.naziv;
                        kontejnerZaPtice.innerHTML=this.URLSlike;
                */
                        


                    
                }

            });
            
       

        }

    }
}
