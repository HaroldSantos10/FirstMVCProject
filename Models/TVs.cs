using System;
using System.ComponentModel.DataAnnotations;

namespace ComputProject.Models
{
    public class TVs
    {
    //definir propiedades
        [Key]
    
        public int tvId {get; set;}

        [Required(ErrorMessage="Brand is required!")]
        [Display(Name="Brand")]
        public string marca {get; set;}
        [Required(ErrorMessage="Model is required!")]
        [Display(Name="Model")]
        [StringLength(100)]
        public string modelo {get; set;}
        [Required(ErrorMessage="Color is required!")]
        [Display(Name="Color")]
        public string color {get; set;}
        [Required(ErrorMessage="Size is required!")]
        [Display(Name="Size")]
        public int size {get; set;}
        [Required(ErrorMessage="Year is required!")]
        [Display(Name="Year")]
        public string year {get; set;}
        //referencias para Store (tienda donde comprar el Tv)

        [Required(ErrorMessage ="Store is required")]
        [Display(Name ="Store")]
        public int storeId{get; set;}
        public Store Stores {get; set;}
        
    }
}