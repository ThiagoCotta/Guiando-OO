using static System.Console;

namespace guiando_oo.src.Classes
{
    public class Produto
    {
        public Produto(int Id, string Nome, double Valor, int QtdeEstoque, int FornecedorComprar)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Valor = Valor;
            this.QtdeEstoque = QtdeEstoque;
            this.FornecedorComprar = FornecedorComprar;
        }

        public Produto()
        {

        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public int QtdeEstoque { get; set; }
        public int FornecedorComprar { get; set; }
        public void DebitarEstoque(int qtd)
        {
            if ((QtdeEstoque - qtd) <= 0)
            {
                WriteLine("Você não possui essa quantidade em estoque");
            }
            else
            {
                QtdeEstoque -= qtd;
                WriteLine("Restam apenas " + QtdeEstoque + " unidades de " + Nome);
            }
        }
    }
}
