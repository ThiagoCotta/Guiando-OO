using static System.Console;

namespace guiando_oo.src.Classes
{ 
    public class Venda
    {
        public Venda(int Id, string DataVenda, int Cliente, int Produto, int QtdeVendida, double Total)
        {
            this.Id = Id;
            this.DataVenda = DataVenda;
            this.Cliente = Cliente;
            this.Produto = Produto;
            this.QtdeVendida = QtdeVendida;
            this.Total = Total;
        }

        public Venda()
        {

        }
        public int Id { get; set; }
        public string DataVenda { get; set; }
        public int Cliente { get; set; }
        public int Produto { get; set; }
        public int QtdeVendida { get; set; }
        public double Total { get; set; }
        
    }
}
