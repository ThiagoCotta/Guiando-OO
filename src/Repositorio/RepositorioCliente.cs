using static System.Console;
using guiando_oo.src.Classes;

namespace guiando_oo.src.Repositorio
{
    public class RepositorioDeCliente
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public RepositorioDeCliente()
        {
            
        }

        public Boolean InserirCliente(Cliente cliente)
        {
            Boolean resultado = true;
            try
            {
                Cliente c = Clientes.Find(x => x.Id == cliente.Id);
                if(c == null)
                {
                    Clientes.Add(cliente);
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
