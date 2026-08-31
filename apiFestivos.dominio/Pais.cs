using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.dominio
{
    [Table("Pais")]
    public class Pais
    {

        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Propiedad de navegación (relación 1 a muchos con Festivo)
        public ICollection<Festivo> Festivos { get; set; } = new List<Festivo>();
    }
}
