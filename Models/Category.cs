using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_core_api.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }
        public string Name { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public int ProductId { get; set; }
    }
}