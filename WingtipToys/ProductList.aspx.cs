using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }
    }
}
/* preencher o controle ListView com os dados do produto do banco de dado. O código dá suporte à 
 * exibição de todos os produtos e produtos de categoria individuais.
 
 Esse código mostra o método GetProducts que a propriedade ItemType do controle ListView faz
referência na página ProductList. aspx . Para limitar os resultados a uma categoria de banco de dados
específica, o código define o valor categoryId do valor da cadeia de caracteres de consulta passado para
a página ProductList. aspx quando a página ProductList. aspx é navegada. A classe QueryStringAttribute no
namespace System.Web.ModelBinding é usada para recuperar o valor da variável de cadeia de caracteres de 
consulta id. Isso instrui a associação de modelo para tentar associar um valor da cadeia de caracteres 
de consulta ao parâmetro categoryId em tempo de execução.

Quando uma categoria válida é passada como uma cadeia de caracteres de consulta para a página, 
os resultados da consulta são limitados a esses produtos no banco de dados que correspondem ao
valor de categoryId. Por exemplo, se a URL da página ProductList. aspx for esta:
http://localhost/ProductList.aspx?id=1

 */