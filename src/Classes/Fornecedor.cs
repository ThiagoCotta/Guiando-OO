using static System.Console;

namespace guiando_oo.src.Classes
{ 
    public class Fornecedor : Pessoa
    {
        public Fornecedor(int Id, string Nome, int Cnpj)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Cnpj = Cnpj;
        }

        public Fornecedor()
        {

        }
        public int Cnpj { get; set; }
        public int Id { get; set; }
    }
}
