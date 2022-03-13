using static System.Console;
using guiando_oo.src.Classes;

namespace guiando_oo.src.Repositorio
{
    public class RepositorioDeFornecedor
    {
        public List<Fornecedor> Fornecedores = new List<Fornecedor>();
        public RepositorioDeFornecedor()
        {
            
        }

        public Boolean InserirFornecedor(Fornecedor fornecedor)
        {
            Boolean resultado = true;
            try
            {
                Fornecedor c = Fornecedores.Find(x => x.Id == fornecedor.Id);
                if(c == null)
                {
                    Fornecedores.Add(fornecedor);
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
