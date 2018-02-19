using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab1_Edwin.Models
{
    public class Jugadores
    {
        [Key]
        public int ID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El nombre es requerido")]
        [StringLength(20, ErrorMessage = "El nombre no puede ser mayor a 20 caracteres")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El apellido es requerido")]
        [StringLength(30, ErrorMessage = "El apellido no puede ser mayor a 30 caracteres")]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "La posición es requerida")]
        [Display(Name = "Posición dentro del campo")]
        public string Posición { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El salario es requerido")]
        [Display(Name = "Salario")]
        [Range(1000, 100000, ErrorMessage = "El salario debe ser entre $1000 y $100000")]
        public decimal Salario { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "El salario es requerido")]
        [Display(Name = "Salario")]
        [Range(1000, 100000, ErrorMessage = "El salario debe ser entre $1000 y $100000")]
        public decimal Compensaciones { get; set; }

        public string Club { get; set; }
    }
}