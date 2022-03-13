using static System.Console;
using guiando_oo.src.Classes;

namespace guiando_oo.src.Repositorio
{
    public class RepositorioDeProduto
    {
        public List<Produto> Produtos = new List<Produto>();
        public RepositorioDeProduto()
        {
            
        }

        public Boolean InserirProduto(Produto produto)
        {
            Boolean resultado = true;
            try
            {
                Produto c = Produtos.Find(x => x.Id == produto.Id);
                if(c == null)
                {
                    Produtos.Add(produto);
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
