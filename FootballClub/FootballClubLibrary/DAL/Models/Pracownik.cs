﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubLibrary.Models
{
    [Table("Pracownicy")]
    public class Pracownik 
    {
        [Key]
        public Guid IdPracownik { get; set; }

        [MaxLength(30)]
        public string? Imie { get; set; }

        [MaxLength(30)]
        public string? Nazwisko { get; set; }

        [RegularExpression(@"^\d{11}$")]
        public string? PESEL { get; set; }

        [Range(16, 99)]
        public int Wiek { get; set; }

        [MaxLength(30)]
        public string? WykonywanaFunkcja { get; set; }

        public decimal Wynagrodzenie { get; set; }

		public Guid? IdZarzadu { get; set; }
		[ForeignKey(nameof(IdZarzadu))]
        public Zarzad? Zarzad { get; set; }

    }
}