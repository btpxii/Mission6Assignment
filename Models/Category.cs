using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission6Assignment.Models
{
    // builds class Category, which has an id key and a name value
    public class Category
    {
        [Key]
        [Required]

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
