using System.Data.Entity;
namespace WingtipToys.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("WingtipToys")
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
/*Esse código adiciona o namespace System.Data.Entity para que você tenha acesso a toda a funcionalidade 
 * básica do Entity Framework, que inclui a capacidade de consultar, inserir, atualizar e excluir dados 
 * trabalhando com objetos fortemente tipados.

A classe ProductContext representa Entity Framework contexto de banco de dados do produto, que lida com a 
busca, o armazenamento e a atualização de Product instâncias de classe no banco de dados. 
A classe ProductContext deriva da class e base DbContext fornecida pelo Entity Framework.

 
  o código no arquivo ProductContext.cs adiciona o System.Data.Entity namespace para que você tenha acesso a todas as funcionalidades principais do Entity Framework. Essa funcionalidade inclui a capacidade de consultar, inserir, atualizar e excluir dados trabalhando com objetos fortemente tipados. O código acima na ProductContext classe adiciona Entity Framework acesso às classes e ao recém-adicionado Order OrderDetail .*/

