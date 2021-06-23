<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="WingtipToys.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Shopping Cart</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        ItemType="WingtipToys.Models.CartItem" SelectMethod="GetShoppingCartItems" 
        CssClass="table table-striped table-bordered" >   
        <Columns>
        <asp:BoundField DataField="ProductID" HeaderText="ID" SortExpression="ProductID" />        
        <asp:BoundField DataField="Product.ProductName" HeaderText="Name" />        
        <asp:BoundField DataField="Product.UnitPrice" HeaderText="Price (each)" DataFormatString="{0:c}"/>     
        <asp:TemplateField   HeaderText="Quantity">            
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" Width="40" runat="server" Text="<%#: Item.Quantity %>"></asp:TextBox> 
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Item Total">            
                <ItemTemplate>
                    <%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantity)) *  Convert.ToDouble(Item.Product.UnitPrice)))%>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Remove Item">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Order Total: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
     <table> 
    <tr>
      <td>
        <asp:Button ID="UpdateBtn" runat="server" Text="Update" OnClick="UpdateBtn_Click" />
      </td>
      <td>
        <!--Checkout Placeholder -->
      </td>
    </tr>
    </table>
</asp:Content>

<%--A página ShoppingCart. aspx inclui um controle GridView chamado CartList. Esse controle usa a associação
    de modelo para associar os dados do carrinho de compras do banco de dado ao controle GridView . 
    Quando você define a propriedade ItemType do controle GridView , a expressão de vinculação de dados
    Item está disponível na marcação do controle e o controle se torna fortemente tipado. 
    Conforme mencionado anteriormente nesta série de tutoriais, você pode selecionar detalhes do objeto
    de Item usando o IntelliSense. Para configurar um controle de dados para usar a associação de modelo 
    para selecionar dados, defina a propriedade SelectMethod do controle. Na marcação acima, você define
    o SelectMethod para usar o método GetShoppingCartItems, que retorna uma lista de objetos CartItem. O 
    controle de dados GridView chama o método no momento apropriado no ciclo de vida da página e associa 
    os dados retornados automaticamente. O método GetShoppingCartItems ainda deve ser adicionado.
    
    Quando o usuário clica no botão Atualizar , o manipulador de eventos UpdateBtn_Click será chamado.
    Esse manipulador de eventos chamará o código que você adicionará na próxima etapa.

Em seguida, você pode atualizar o código contido no arquivo ShoppingCart.aspx.cs para executar um loop pelos 
    itens do carrinho e chamar os métodos RemoveItem e UpdateItem.--%>