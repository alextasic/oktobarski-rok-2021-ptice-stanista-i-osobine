using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Podrucje
    {
        [Key]
        public int ID{get;set;}

        public string Naziv{get;set;}

        public string Opis { get; set; }

        [JsonIgnore]
        public List<PticaPodrucje> PticaPodrucje{get;set;}
    }
}