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
    [Table("Zarzady")]
    public class Zarzad
    {
        [Key]
        public Guid IdZarzad { get; set; }

        public ICollection<Pracownik> Pracownicy { get; set; }

        [Required]
        public decimal Budzet { get; set; }

        [Required]
        public ICollection<string> Cele { get; set; }

        public Klub Klub { get; set; }

        public Guid IdKlubu { get; set; }
    }
}
