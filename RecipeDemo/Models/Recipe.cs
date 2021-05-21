using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeDemo.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

    }
}
