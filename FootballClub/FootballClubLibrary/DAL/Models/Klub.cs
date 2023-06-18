using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubLibrary.Models
{
    [Table("Kluby")]
    public class Klub
    {
        [Key]
        public Guid IdKlub { get; set; }
        public string? Nazwa { get; set; }

        [MaxLength(50)]
        public string? Stadion { get; set; }

        public string Trofea { get; set; }

        public ICollection<Pilkarz>? ArchwilaniPilkarze { get; set; }

        public ICollection<Pilkarz>? ObecniPilkarze { get; set; }

        public Zarzad? Zarzad { get; set; }
    }
}