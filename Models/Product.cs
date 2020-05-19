using System;

namespace GMartWebServices.Models
{
    public class Product
    {
        public int id{get;set;}
        public string Product_Name{get;set;}
        public string Company{get;set;}
        public decimal Product_Price{get;set;}

        public decimal Product_Type{get;set;}

        
           //constructor(except id)-->by admin to add prod
    } 
}