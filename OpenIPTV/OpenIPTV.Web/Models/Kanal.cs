using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpenIPTV.Web.Models
{
    [Table("Kanali")]
    public class Kanal
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(32)]
        public string Naziv { get; set; }

        public int Broj { get; set; }

        [MaxLength(16)]
        public string Logo { get; set; }
    }
}