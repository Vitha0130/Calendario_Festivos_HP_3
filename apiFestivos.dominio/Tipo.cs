using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.dominio
{
    [Table("Tipo")]
    public class Tipo
    {

        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Tipo")]
        [Required]
        [MaxLength(100)]
        public string Tipo1 { get; set; } = string.Empty; 
        public ICollection<Festivo> Festivos { get; set; } = new List<Festivo>();
    }
}
