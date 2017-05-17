using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_core_api.DTO
{
    public class ProductDTO
    {       
        public int Key { get; set; }
        
        [Required(ErrorMessage ="You should provide a name value.")]
        [MinLength(2)]
        [MaxLength(10)]        
        public string Name { get; set; }    

         public int NumberOfCategories { get
            {
                return Categories.Count;
            }
        }

        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();    
    }
}