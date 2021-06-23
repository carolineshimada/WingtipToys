using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class CartItem
    {
        [Key]
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public System.DateTime DateCreated { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

    }
}
/*A classe CartItem contém o esquema que definirá cada produto que um usuário adiciona ao
 * carrinho de compras. Essa classe é semelhante às outras classes de esquema que você criou
 * anteriormente nesta série de tutoriais. Por convenção, Entity Framework Code First espera
 * que a chave primária para a tabela CartItem seja CartItemId ou ID. No entanto, o código 
 * substitui o comportamento padrão usando o atributo Data Annotation [Key]. O atributo Key 
 * da propriedade ItemId especifica que a propriedade ItemID é a chave primária.

A propriedade CartId especifica o ID do usuário que está associado ao item a ser comprado.
Você adicionará código para criar esse usuário ID quando o usuário acessar o carrinho de 
compras. Essa ID também será armazenada como uma variável de sessão ASP.NET.*/