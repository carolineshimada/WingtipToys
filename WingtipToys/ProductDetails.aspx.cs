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
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new WingtipToys.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProductID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}
/*Esse código verifica um valor de cadeia de caracteres de consulta "productID". 
 * Se um valor de cadeia de caracteres de consulta válido for encontrado, o produto
 * correspondente será exibido. Se a cadeia de caracteres de consulta não for encontrada 
 * ou seu valor não for válido, nenhum produto será exibido.*/