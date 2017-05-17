using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_core_api.DTO
{
    public class CategoryDTO
    {       
        public int Key { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }      
    }
}