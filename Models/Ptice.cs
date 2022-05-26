using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    public class Ptica
{
        [Key]
        public int ID { get; set; }

        [MaxLength(50)]
        public string Naziv { get; set; }

        [MaxLength(100)]
        public string URLSlike { get; set; }

        [JsonIgnore]
        public List<Osobina> Osobine { get; set; }//tu treba List<Osobina> Osobine 

        [JsonIgnore]
        public List<PticaPodrucje> PticaPodrucja { get; set; }
}
}