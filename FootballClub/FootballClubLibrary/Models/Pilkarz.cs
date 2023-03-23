﻿using Microsoft.EntityFrameworkCore;
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

        [MaxLength(30), Required]
        public string Pozycja { get; set; }

        public ICollection<Statystyka>? Statystyki { get; set; }

        public ICollection<Klub>? ArchiwalneKluby { get; set; }

        [Required]
        public decimal Wynagrodzenie { get; set; }

        public Guid IdKlubu { get; set; }

        [ForeignKey(nameof(IdKlubu))]
        public Klub Klub { get; set; }

    }
}
