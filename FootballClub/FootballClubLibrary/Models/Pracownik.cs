using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballClubLibrary.Models
{
    [Table("Pracownicy")]
    public class Pracownik 
    {
        [Key]
        public Guid IdPracownik { get; set; }

        [MaxLength(30), Required]
        public string Imie { get; set; }

        [MaxLength(30), Required]
        public string Nazwisko { get; set; }

        [Required]
        [RegularExpression(@"^\d{11}$")]
        public string PESEL { get; set; }

        [Range(16, 99), Required]
        public int Wiek { get; set; }

        [MaxLength(30), Required]
        public string WykonywanaFunkcja { get; set; }

        public Guid IdZarzadu { get; set; }

        [ForeignKey(nameof(IdZarzadu))]
        public Zarzad Zarzad { get; set; }

    }
}
