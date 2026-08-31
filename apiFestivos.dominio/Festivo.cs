using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apiFestivos.dominio
{

    [Table("Festivo")]
    public class Festivo
    {

        [Column("Id")]
        [Key]
        public int Id { get; set; }

        [Column("Nombre")]
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Column("Dia")]
        [Required]
        public int Dia { get; set; }

        [Column("Mes")]
        [Required]
        public int Mes { get; set; }

        [Column("DiasPascua")]
        [Required]
        public int DiasPascua { get; set; }

        [Column("IdTipo")]
        [Required]
        [ForeignKey(nameof(Tipo))]
        public int IdTipo { get; set; }
        public Tipo Tipo { get; set; } = null!;

        [Column("IdPais")]
        [Required]
        [ForeignKey(nameof(Pais))]
        public int IdPais { get; set; }
        public Pais Pais { get; set; } = null!;
    }
}
