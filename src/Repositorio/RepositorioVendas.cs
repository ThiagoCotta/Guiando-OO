using static System.Console;
using guiando_oo.src.Classes;

namespace guiando_oo.src.Repositorio
{
    public class RepositorioDeVenda
    {
        public List<Venda> Vendas = new List<Venda>();
        public RepositorioDeVenda()
        {
            
        }

        public Boolean InserirVenda(Venda venda)
        {
            Boolean resultado = true;
            try
            {
                Venda c = Vendas.Find(x => x.Id == venda.Id);
                if(c == null)
                {
                    Vendas.Add(venda);
                }
                else
                {
                    resultado = false;
                }
            }
            catch (Exception erro)
            {
                resultado = false;
            } 
            return resultado;
        }
    
    }
}
