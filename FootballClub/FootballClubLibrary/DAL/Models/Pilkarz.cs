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
    [Table("Pilkarze")]
    public class Pilkarz
    {
        [Key]
        public Guid IdPilkarz { get; set; }

        [MaxLength(30)]
        public string Imie { get; set; }
        
        [MaxLength(30)]
        public string Nazwisko { get; set; }

        [Range(16,50)]
        public int Wiek { get; set; }

        [MaxLength(30)]
        public string? Pozycja { get; set; }

        public ICollection<Statystyka>? Statystyki { get; set; }

        public ICollection<Klub>? ArchiwalneKluby { get; set; }

        public decimal Wynagrodzenie { get; set; }

        public Guid? IdKlubu { get; set; }

        [ForeignKey(nameof(IdKlubu))]
        public Klub? Klub { get; set; }

    }
}
