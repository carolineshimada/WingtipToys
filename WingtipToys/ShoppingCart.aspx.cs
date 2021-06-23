using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ShoppingCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                decimal cartTotal = 0;
                cartTotal = usersShoppingCart.GetTotal();
                if (cartTotal > 0)
                {
                    // Display Total.
                    lblTotal.Text = String.Format("{0:c}", cartTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    ShoppingCartTitle.InnerText = "Shopping Cart is Empty";
                    UpdateBtn.Visible = false;
                }
            }
        }

        public List<CartItem> GetShoppingCartItems()
        {
            ShoppingCartActions actions = new ShoppingCartActions();
            return actions.GetCartItems();
        }

        public List<CartItem> UpdateCartItems()
        {
            using (ShoppingCartActions usersShoppingCart = new ShoppingCartActions())
            {
                String cartId = usersShoppingCart.GetCartId();

                ShoppingCartActions.ShoppingCartUpdates[] cartUpdates = new ShoppingCartActions.ShoppingCartUpdates[CartList.Rows.Count];
                for (int i = 0; i < CartList.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CartList.Rows[i]);
                    cartUpdates[i].ProductId = Convert.ToInt32(rowValues["ProductID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CartList.Rows[i].FindControl("Remove");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CartList.Rows[i].FindControl("PurchaseQuantity");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.UpdateShoppingCartDatabase(cartId, cartUpdates);
                CartList.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCartItems();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            UpdateCartItems();
        }
    }
}
/*Como mencionado acima, o controle de dados GridView chama o método GetShoppingCartItems 
 * no momento apropriado do ciclo de vida da página e associa os dados retornados automaticamente.
 * O método GetShoppingCartItems cria uma instância do objeto ShoppingCartActions. Em seguida, 
 * o código usa essa instância para retornar os itens no carrinho chamando o método GetCartItems.
 
 
 
 Quando a página ShoppingCart. aspx é carregada, ela carrega o objeto de carrinho de compras e, 
em seguida, recupera o total do carrinho de compras chamando o método GetTotal da classe ShoppingCart. 
Se o carrinho de compras estiver vazio, será exibida uma mensagem para esse efeito.

 
 
 Quando o usuário clica no botão Atualizar na página ShoppingCart. aspx , o método UpdateCartItems 
é chamado. O método UpdateCartItems Obtém os valores atualizados para cada item no carrinho de compras.
Em seguida, o método UpdateCartItems chama o método UpdateShoppingCartDatabase (adicionado e explicado 
na próxima etapa) para adicionar ou remover itens do carrinho de compras. Depois que o banco de dados 
tiver sido atualizado para refletir as atualizações para o carrinho de compras, o controle GridView será
atualizado na página do carrinho de compras chamando o método DataBind para GridView. Além disso, o valo
r total do pedido na página do carrinho de compras é atualizado para refletir a lista atualizada de itens.*/