using static System.Console;
using guiando_oo.src.Repositorio;

namespace guiando_oo.src.Classes
{
    public class Cliente : Pessoa
    {
        public Cliente(int Id, string Nome, int Cpf)
        {
            this.Id = Id;
            this.Nome = Nome;
            this.Cpf = Cpf;
        }

        public Cliente()
        {

        }
        public int Cpf { get; set; }
        public int Id { get; set; }
    }
}
