using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubLibrary.Models
{
    [Table("Kluby")]
    public class Klub
    {
        [Key]
        public Guid IdKlub { get; set; }

        [StringLength(20, ErrorMessage = "Za długa nazwa klubu !")]
        public string? Nazwa { get; set; }

        [StringLength(30, ErrorMessage= "Za dluga nazwa stadionu !")]
        public string? Stadion { get; set; }

        public string Trofea { get; set; }

        public ICollection<Pilkarz>? ArchiwalniPilkarze { get; set; }

        public ICollection<Pilkarz>? ObecniPilkarze { get; set; }

        public Zarzad? Zarzad { get; set; }
    }
}