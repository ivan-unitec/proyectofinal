using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NombreDeTuProyecto.Models
{
    public class Alumno
    {
        [Key]
        public Guid Id { get; set; }          // Clave primaria, equivalente a uniqueidentifier en SQL

        [Required]
        [StringLength(128)]
        public string Nombre { get; set; }    // Nombre del alumno, con longitud máxima de 128 caracteres

        [Required]
        public int Cuenta { get; set; }       // Número de cuenta del alumno

        [Required]
        public float Promedio { get; set; }   // Promedio del alumno, equivalente a float en SQL
    }
}
