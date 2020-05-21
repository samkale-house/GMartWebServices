using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GMartWebServices.Models
{
    public class Product
    {
        public int ID{get;set;}
        
        [Required]
        [MaxLength(60)]
        public string Product_Name{get;set;}
        
        [Required]
        [MaxLength(30)]
        public string Company{get;set;}
        
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Product_Price{get;set;}

        public int Product_Type{get;set;}

        
           //constructor(except id)-->by admin to add prod
    } 
}