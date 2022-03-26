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
           var p = await Context.Ptica.Include(p => p.Osobine)
               .Where(p=>izabraneOsobine.Contains((p.Osobine.ID).ToString()))/////////////////moras konverovati u string ako trazis u stringu
               .Include(p=>p.PticaPodrucja).Where(p=>p.PticaPodrucja.Any(q=>q.Podrucje.ID==izabranoPodrucje)).ToListAsync();
               
            return p;
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
        else return BadRequest("");
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