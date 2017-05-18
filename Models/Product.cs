using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_core_api.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }
        public string Name { get; set; } 
        public decimal Price {get; set;}
        public bool IsActive {get; set;}
        public string Description {get; set;}   

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}