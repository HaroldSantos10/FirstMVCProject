using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComputProject.Models
{
    public class Documento
    {
         [Key]

        public int DocumentoId{get; set;}

        [Required(ErrorMessage="Titulo es requerido")]
        [Display(Name="Titulo")]
        public string titulo {get; set;}

        [Required(ErrorMessage="Contenido es requerido")]
        [Display(Name="Contenido")]
        public string contenido {get; set;}

        [Required(ErrorMessage="fecha de Publicación es requerida")]
        [DataType(DataType.Date)]
        [Display(Name="FechaPublicacion")]
        public string fechapublicacion {get; set;}

        [Required(ErrorMessage="Descripcion es requerida")]
        [Display(Name="Descripcion")]
        public string descripcion {get; set;}
    }
}