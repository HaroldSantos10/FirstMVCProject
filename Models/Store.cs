using System.Collections.Generic;
using System.Security.AccessControl;
using System;
using System.ComponentModel.DataAnnotations;



namespace ComputProject.Models
{
    public class Store
    {
        [Key]   
        public int storeId{get; set;}
        [Required(ErrorMessage ="Name is required!")]
        [Display(Name="Name")]
        public string name{get; set;}
        [Required(ErrorMessage ="Address is required!")]
        [StringLength(100)] //máximo de letras que admite la dirección
        [Display(Name="Address")]
        public string Address{get; set;}
        [Required(ErrorMessage ="Email is required!")]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email", Prompt ="email@domain.com")]
        public string email{get; set;}

        public ICollection<TVs> TVss {get; set;} = new List<TVs>();
        
    }
    
}