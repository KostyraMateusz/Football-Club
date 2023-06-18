using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FootballClubLibrary.Models
{
    [Table("Zarzady")]
    public class Zarzad
    {
        [Key]
        public Guid IdZarzad { get; set; }

        public ICollection<Pracownik>? Pracownicy { get; set; }

		public decimal Budzet { get; set; }

        public string Cele { get; set; }

        public Klub? Klub { get; set; }

        public Guid? IdKlubu { get; set; }
    }
}