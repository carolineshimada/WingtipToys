using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;

namespace WingtipToys
{
    public partial class AddToCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProductID"];
            int productId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out productId))
            {
                using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
                {
                    usersShoppingCart.AddToCart(Convert.ToInt16(rawId));
                }

            }
            else
            {
                Debug.Fail("ERROR : We should never get to AddToCart.aspx without a ProductId.");
                throw new Exception("ERROR : It is illegal to load AddToCart.aspx without setting a ProductId.");
            }
            Response.Redirect("ShoppingCart.aspx");
        }
    }
}

/*Quando a página addToCart. aspx é carregada, o produto ID é recuperado da cadeia de caracteres de consulta.
 * Em seguida, uma instância da classe de carrinho de compras é criada e usada para chamar o método de
 * AddToCart que você adicionou anteriormente neste tutorial. O método AddToCart, contido no arquivo 
 * ShoppingCartActions.cs , inclui a lógica para adicionar o produto selecionado ao carrinho de compras
 * ou incrementar a quantidade de produtos do produto selecionado. Se o produto não tiver sido adicionado
 * ao carrinho de compras, o produto será adicionado à tabela de CartItem do banco de dados. Se o produto 
 * já tiver sido adicionado ao carrinho de compras e o usuário adicionar um item adicional do mesmo produto,
 * a quantidade de produtos será incrementada na tabela de CartItem. Por fim, a página redireciona de volta
 * para a página ShoppingCart. aspx que você adicionará na próxima etapa, em que o usuário vê uma lista 
 * atualizada de itens no carrinho.

Como mencionado anteriormente, um ID de usuário é usado para identificar os produtos que estão associados 
a um usuário específico. Essa ID é adicionada a uma linha na tabela CartItem cada vez que o usuário adiciona 
um produto ao carrinho de compras.*/