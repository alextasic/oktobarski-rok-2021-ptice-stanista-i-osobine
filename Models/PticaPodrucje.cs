using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class PticaPodrucje
    {
        [Key]
        public int ID { get; set; }

        public int VidjenaPuta { get; set; }

        [JsonIgnore]
        public Ptica Ptica { get; set; }

        [JsonIgnore]
        public Podrucje Podrucje { get; set; }
}
}