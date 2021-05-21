using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeDemo.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [Required(ErrorMessage ="Kategori Adı Boş Geçilemez")]
        [StringLength(20,ErrorMessage ="3-20 arasında karakter girişi yapınız!",MinimumLength =3)]
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public string CategoryImageURL { get; set; }

        public bool Status { get; set; }
        public List<Recipe> Recipes { get; set; }

       
    }
}
