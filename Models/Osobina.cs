using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Osobina
    {
        [Key]
        public int ID{get;set;}

        [MaxLength(20)]
        public string Naziv { get; set; }

        [MaxLength(100)]
        public string Vrednost { get; set; }

     /*   public string Vrednost2 { get; set; }

        public string Vrednost3 { get; set; }*/

        [JsonIgnore]
        public List<Ptica> Ptice { get; set; }

    }
}