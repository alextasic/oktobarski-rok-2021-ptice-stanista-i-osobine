using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;/////////////////////DODATO!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
using System.Linq;////////////////dodato automatski

namespace Template.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IspitController : ControllerBase
    {
        IspitDbContext Context { get; set; }

        public IspitController(IspitDbContext context)
        {
            Context = context;
        }

        [Route("PreuzmiPodrucja")]
        [HttpGet]
        public async Task<List<Podrucje>> PreuzmiPodrucja()
        {
           return await Context.Podrucje.ToListAsync();
        }

        [Route("PreuzmiOsobine")]
        [HttpGet]
        public async Task<List<Osobina>> PreuzmiOsobine()
        {
           return await Context.Osobina.ToListAsync();
        }

        [Route("TrazenjePtica/{izabraneOsobine}/{izabranoPodrucje}")]
        [HttpGet]
        public async Task<List<Ptica>> TrazenjePtica(string izabraneOsobine,int izabranoPodrucje)
        {
            /*Svejedno je koji upit ces koristiti. Ono sto je jasno, to je da ce ti vratiti pticu ako si selektovao sve osobine koje za tu vrstu ima u bazi, pa i neke koje ona nema.*/
           /* var p = await Context.Ptica.Include(p => p.Osobine).Include(p=>p.PticaPodrucja).
                                Where(p=>p.Osobine.All(q => izabraneOsobine.Contains(q.ID.ToString()))//q se odnosi na Osobine
                                && p.PticaPodrucja.Any(q=>q.Podrucje.ID==izabranoPodrucje)).ToListAsync();//a ovde se q odnosi na PticaPodrucje
            return p;  */            
            var p = await Context.Ptica.Include(p => p.Osobine).Where(p=>p.Osobine.All(q => izabraneOsobine.Contains(q.ID.ToString())))//q se odnosi na Osobine
                                       .Include(p=>p.PticaPodrucja).Where(p=>p.PticaPodrucja.Any(q=>q.Podrucje.ID==izabranoPodrucje)).ToListAsync();
            return p;
            ////////////upit https://localhost:5001/Ispit/TrazenjePtica/12/2 vraca [{"id":2,"naziv":"Svraka","urlSlike":"slika1"},{"id":4,"naziv":"soko","urlSlike":"slika4"},{"id":5,"naziv":"sova","urlSlike":"slika5"}] /
                            //*a upit https://localhost:5001/Ispit/TrazenjePtica/2/2 vraca [{"id":4,"naziv":"soko","urlSlike":"slika4"},{"id":5,"naziv":"sova","urlSlike":"slika5"}] */
        }

        [Route ("DodajPojavuPtice/{pticaID}/{PoducjeID}")]
        [HttpPut]
        public async Task<ActionResult> DodajPojavuPtice(int pticaID,int PoducjeID)
        {
            var a=await Context.PticaPodrucje.Where(p=>p.Ptica.ID==pticaID && p.Podrucje.ID==PoducjeID).FirstOrDefaultAsync();
            
            if (a!=null){
            
                a.VidjenaPuta++;
               
               // Context.PticaPodrucje.Update(a);//////////
                await Context.SaveChangesAsync();////mora se dodati safe changes async
                return Ok("USPESNO DODATA POJAVA");
            }
        else return BadRequest("404");
        }

        [Route ("DodajUSpecijalnuTabelu/{NizSelektovanihOsobina}/{izabranoPodrucje}")]
        [HttpPost]
        public async Task<ActionResult> DodajUSpecijalnuTabelu(string NizSelektovanihOsobina,int izabranoPodrucje){
            if (NizSelektovanihOsobina.Length!=0){
            
            SpecijalnaTabela specijalnaTabela=new SpecijalnaTabela();
            
            specijalnaTabela.Osobine = NizSelektovanihOsobina;

            specijalnaTabela.Podrucje=await Context.Podrucje.Where(p=>p.ID==izabranoPodrucje).FirstAsync();
            
            Context.SpecijalnaTabela.Add(specijalnaTabela);

            await Context.SaveChangesAsync();
            return Ok("uspelo");
            }

            else return BadRequest("404");
        }
    }
}





/*
// C# program for passing the 1-D
// array to method as argument
using System;
 
class GFG {
     
    // declaring a method
    static void Result(int[] arr) {
         
        // displaying the array elements
        for(int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine("Array Element: "+arr[i]);
        }
         
    }
     
    // Main method
    public static void Main() {
         
        // declaring an array
        // and initializing it
        int[] arr = {1, 2, 3, 4, 5};
         
        // calling the method
        Result(arr);
    }
}
Output: */