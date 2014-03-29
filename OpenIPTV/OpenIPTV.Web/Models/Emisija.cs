using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIPTV.Web.Models
{
    [Table("Emisije")]
    public class Emisija
    {
        public int Id { get; set; }
        
        public DateTime Datum { get; set; }
        
        public int Sat { get; set; }
        
        public int Minut { get; set; }

        public TimeSpan Vreme
        {
            get {return new TimeSpan(Sat, Minut, 0);}
        }
        
        [MaxLength(32)]
        public string Tip { get; set; }

        [MaxLength(256)]
        public string Naziv { get; set; }
        
        [MaxLength(2048)]
        public string Opis { get; set; }

        public int KanalId { get; set; }
        
        public Kanal Kanal { get; set; }

        [NotMapped]
        public bool SadaNaProgramu { get; set; }
    }
}