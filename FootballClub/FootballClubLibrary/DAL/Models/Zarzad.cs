using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubLibrary.Models
{
    [Table("Zarzady")]
    public class Zarzad
    {
        [Key]
        public Guid IdZarzad { get; set; }

        public Guid? IdKlubu { get; set; }
        [ForeignKey(nameof(IdKlubu))]
        public Klub? Klub { get; set; }

        public ICollection<Pracownik>? Pracownicy { get; set; }

        [Required]
        public decimal Budzet { get; set; }

        [Required]
        public string Cele { get; set; }
    }
}