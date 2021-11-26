using System; 
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputProject.Models
{
    public class Figura
    {
        [Key]
        public int figuraId{get; set;}

        [Required(ErrorMessage="Nombre es requerido")]
        [Display(Name="Nombre")]
        public string nombre {get; set;}

        [Required(ErrorMessage="Lados es requerido")]
        [Display(Name="Lados")]
        public string lados {get; set;}

        [Required(ErrorMessage="Angulo es requerido")]
        [Display(Name="Angulo")]
        public string angulo {get; set;}
    }
    
}