using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class SpecijalnaTabela
{
        [Key]
        public int ID { get; set; }

        [JsonIgnore]
        //public List<Osobina> Osobine { get; set; }//tu treba List<Osobina> Osobine 
        public string Osobine{get;set;}
        
        [JsonIgnore]
        public Podrucje Podrucje { get; set; }
}
}