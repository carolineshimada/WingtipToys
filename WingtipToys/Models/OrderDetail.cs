using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }

        public string Username { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public double? UnitPrice { get; set; }

    }
}


/*As Order OrderDetail classes e contêm o esquema para definir as informações de pedido usadas para compra e envio.

Além disso, você precisará atualizar a classe de contexto do banco de dados que gerencia as classes de entidade e que fornece acesso a um banco de dado. Para fazer isso, você adicionará as classes de ordem e OrderDetail modelo recém-criadas à ProductContext classe.*/