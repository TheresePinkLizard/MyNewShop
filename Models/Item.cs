using System;
namespace MyNewShop.Models
{
    public class Item {
        public int ItemId { get; set; }
        public string Name { get; set; } = string.Empty; //  = string.Empty;  is to state this is a mandatory value, has empthy string by default. 
                                        //can also use ? on nullable variabels instead, like this code shows
        public decimal Price { get; set; }
        public string? Description { get; set; }    
        public string? ImageUrl { get; set; }

        
    }
}