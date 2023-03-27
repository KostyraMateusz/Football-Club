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
    [Table("Statystki")]
    public class Statystyka
    {
        [Key]
        public Guid IdStatystyka { get; set; }

        public string? Mecz { get; set; }

        public int Gole { get; set; }

        public int Asysty { get; set; }

        [Range(0, 2)]
        public int ZolteKartki { get; set; }

        [Range(0,1)]
        public int CzerwoneKartki { get; set; }

        [Range(0, 15)]
        public double PrzebiegnietyDystans { get; set; }

        [Range(0, 10)]
        public double Ocena { get; set; }

        public Guid? IdPilkarz { get; set; }

        [ForeignKey(nameof(IdPilkarz))]
        public Pilkarz? Pilkarz { get; set; }
    }
}
