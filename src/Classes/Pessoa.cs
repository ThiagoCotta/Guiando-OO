using static System.Console;

namespace guiando_oo.src.Classes
{
    public class Pessoa
    {
        public Pessoa(string Nome)
        {
            this.Nome = Nome;
        }

        public Pessoa()
        {

        }
        public string Nome { get; set; }
    }
}
