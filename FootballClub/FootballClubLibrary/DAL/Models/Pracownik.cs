using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubLibrary.Models
{
    [Table("Pracownicy")]
    public class Pracownik 
    {
        [Key]
        public Guid IdPracownik { get; set; }

        [StringLength(25, ErrorMessage = "Za dlugie imie !")]
        public string? Imie { get; set; }

        [StringLength(20, ErrorMessage = "Za dlugie nazwisko !")]
        public string? Nazwisko { get; set; }

        [RegularExpression(@"^\d{11}$")]
        public string? PESEL { get; set; }

        [Range(16, 99)]
        public int Wiek { get; set; }

        [StringLength(40, ErrorMessage = "Zbyt dluga nazwa wykonywanej funkcji !")]
        public string? WykonywanaFunkcja { get; set; }

        public decimal Wynagrodzenie { get; set; }

        public Guid? IdZarzadu { get; set; }
        [ForeignKey(nameof(IdZarzadu))]
        public Zarzad? Zarzad { get; set; }
    }
}