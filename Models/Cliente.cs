using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ComputProject.Models
{
    public class Cliente
    {
    [Key]

        public int clienteId{get; set;}

        [Required(ErrorMessage="Name is requeried")]
        [Display(Name="Names")]
        public string names {get; set;}

        [Required(ErrorMessage="Address is requeried")]
        [Display(Name="Address")]
        public string address {get; set;}

        [Required(ErrorMessage="Telephone is requeried")]
        [Display(Name="Telephone")]
        public string telephone {get; set;}

        [Required(ErrorMessage="Mobile is requeried")]
        [Display(Name="Mobile")]
        public string mobile {get; set;}
    }
}