using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class Product
    {
        [ScaffoldColumn(false)]
        public int ProductID { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }

        [Required, StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Price")]
        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
/* classe Product representa os produtos individuais (Toys) no banco de dados.
 * Cada instância de um objeto de Product corresponderá a uma linha dentro de 
 * uma tabela de banco de dados relacional e cada propriedade da classe Product 
 * será mapeada para uma coluna na tabela de banco de dados relacional*/