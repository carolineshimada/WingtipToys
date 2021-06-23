<%@ Page Title="Product Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductDetails.aspx.cs" Inherits="WingtipToys.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server" ItemType="WingtipToys.Models.Product" SelectMethod ="GetProduct" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.ProductName %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <img src="/Catalog/Images/<%#:Item.ImagePath %>" style="border:solid; height:300px" alt="<%#:Item.ProductName %>"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Description:</b><br /><%#:Item.Description %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.ProductID %></span>
                        <br />
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
<%--Esse código usa um controle FormView para exibir detalhes específicos do produto. 
    Essa marcação usa métodos como os métodos usados para exibir dados na página ProductList. aspx .
    O controle FormView é usado para exibir um único registro por vez de uma fonte de dados.
    Quando você usa o controle FormView , cria modelos para exibir e editar valores associados a dados. 
    Esses modelos contêm controles, expressões de associação e formatação que definem a aparência e a 
    funcionalidade do formulário.--%>