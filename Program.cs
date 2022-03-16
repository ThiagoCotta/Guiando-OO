using static System.Console;
using guiando_oo.src.Classes;
using guiando_oo.src.Repositorio;
class Program
{
    //MENUS
    static int MostrarMenu()//Show Menu Inicial
    {
        Clear();
        WriteLine("Bem vindo ao depósito UNA");
        WriteLine("Oque deseja fazer?");
        WriteLine("1 - Cliente");
        WriteLine("2 - Fornecedor");
        WriteLine("3 - Produto");
        WriteLine("4 - Venda");
        WriteLine("5 - Histórico");
        WriteLine(" ");
        WriteLine(" ");
        WriteLine("0 - Sair");
        Write("Opção: ");

        int escolha = Convert.ToInt32(ReadLine());

        return escolha;
    }
    static int MenuCliente()//Show Menu Cliente
    {
        Clear();
        WriteLine("1 - Cadastrar cliente: ");
        WriteLine("2 - Listar clientes: ");
        WriteLine(" ");
        int escolhacliente = 0;
        try
        {
            escolhacliente = Convert.ToInt32(ReadLine());

        }
        catch
        {
            WriteLine("Valor inválido");
        }
        return escolhacliente;
    }
    static int MenuFornecedor()//Show Menu Fornecedor 
    {
        Clear();
        WriteLine("1 - Cadastrar fornecedor: ");
        WriteLine("2 - Listar fornecedores: ");
        WriteLine("3 - Comprar Produto: ");
        WriteLine(" ");
        int escolhafornecedor = 0;
        try
        {
            escolhafornecedor = Convert.ToInt32(ReadLine());

        }
        catch
        {
            WriteLine("Valor inválido");
        }

        return escolhafornecedor;
    }
    static int MenuProduto() //Show Menu Produto
    {
        Clear();
        WriteLine("1 - Listar produtos: ");
        WriteLine(" ");
        int escolhaProduto = 0;

        try
        {
            escolhaProduto = Convert.ToInt32(ReadLine());
        }
        catch
        {
            WriteLine("Valor inválido");
        }

        return escolhaProduto;
    }

    //CADASTRAR
    static void CadastrarCliente(Cliente cliente, int IdCliente, RepositorioDeCliente listadeclientes)
    {
        Clear();
        Write("Nome: ");
        string Nome = ReadLine();
        try
        {
            Write("CPF: ");
            int Cpf = Convert.ToInt16(ReadLine());
            if (Cpf.GetType() == typeof(int))
            {
                cliente = new Cliente(IdCliente, Nome, Cpf);
                listadeclientes.InserirCliente(cliente);

            }

        }
        catch (Exception erro)
        {
            WriteLine(" ");
            WriteLine("O CPF deve ser um número positivo! ");
            WriteLine("Tente novamente");
        }

        PressioneAlgo();
    }
    static void CadastrarFornecedor(Fornecedor fornecedor, int IdFornecedor, RepositorioDeFornecedor listadefornecedores)
    {
        Clear();
        Write("Nome: ");
        string Nome = ReadLine();
        try
        {
            Write("CNPJ: ");
            int Cnpj = Convert.ToInt32(ReadLine());
            if (Cnpj.GetType() == typeof(int))
            {
                int Id = IdFornecedor++;
                fornecedor = new Fornecedor(Id, Nome, Cnpj);
                listadefornecedores.InserirFornecedor(fornecedor);
            }
        }
        catch (Exception erro)
        {
            WriteLine(" ");
            WriteLine("O CNPJ deve ser um número positivo! ");
            WriteLine("Tente novamente");
        }

        PressioneAlgo();
    }
    static int CadastrarProduto(RepositorioDeFornecedor listadefornecedores, int comprarDoFornecedor, Produto produto, RepositorioDeProduto listadeprodutos, int IdProduto)
    {
        Clear();
        int escolhaCompra = 10;
        if (listadefornecedores.Fornecedores.Exists(x => x.Id == comprarDoFornecedor))
        {
            while (escolhaCompra != 0)
            {
                Write("Nome do produto: ");
                string NomeProduto = ReadLine();
                try
                {
                    Write("Valor: R$");
                    double Valor = Convert.ToDouble(ReadLine());
                    if (Valor.GetType() == typeof(double))
                    {
                        Write("Quantidade que deseja comprar: ");
                        int QtdeEstoque = Convert.ToInt32(ReadLine());
                        int CodigoProduto = IdProduto++;
                        produto = new Produto(CodigoProduto, NomeProduto, Valor, QtdeEstoque, comprarDoFornecedor);
                        listadeprodutos.InserirProduto(produto);
                    }

                }
                catch (Exception erro)
                {
                    WriteLine(" ");
                    WriteLine("Você deve digitar um valor positivo válido! ");
                    WriteLine("Tente novamente");
                }

                TxtContinuar();

                escolhaCompra = Convert.ToInt32(ReadLine());
                Clear();
            }
        }
        else
        {
            WriteLine("Não exite um fornecedor com o ID " + comprarDoFornecedor);
        }

        return escolhaCompra;
    }

    //LISTAR
    static void Listar(RepositorioDeCliente listadeclientes) //Listar Cliente
    {
        Clear();
        WriteLine("Lista de Clientes: ");
        foreach (var j in listadeclientes.Clientes)
        {
            WriteLine(" ");
            WriteLine("Id: #" + j.Id);
            WriteLine("Nome: " + j.Nome);
            WriteLine("CPF: " + j.Cpf);
        }

        PressioneAlgo();
    }
    static void Listar(RepositorioDeFornecedor listadefornecedores) //Listar Fornecedor
    {
        Clear();
        WriteLine("Lista de Fornecedores: ");
        foreach (var j in listadefornecedores.Fornecedores)
        {
            WriteLine(" ");
            WriteLine("Id: #" + j.Id);
            WriteLine("Nome: " + j.Nome);
            WriteLine("CNPJ: " + j.Cnpj);
        }

        PressioneAlgo();
    }
    static void Listar(RepositorioDeProduto listadeprodutos) //Listar Produtos
    {
        Clear();
        WriteLine("Lista de produtos: ");
        foreach (var j in listadeprodutos.Produtos)
        {
            WriteLine(" ");
            WriteLine("Id: #" + j.Id);
            WriteLine("Nome: " + j.Nome);
            WriteLine("Valor: R$: " + j.Valor);
            WriteLine("Quantidade no estoque: " + j.QtdeEstoque);
            WriteLine("Produto comprado pelo fornecedor " + j.FornecedorComprar);

        }

        PressioneAlgo();
    }
    static void Listar(RepositorioDeVenda listadevendas, RepositorioDeCliente listadeclientes, RepositorioDeProduto listadeprodutos) //Listar Vendas
    {
        Clear();
        WriteLine("Lista de vendas realizadas: ");
        foreach (var j in listadevendas.Vendas)
        {
            WriteLine(" ");
            WriteLine("Vendido no dia " + j.DataVenda);
            WriteLine("Cliente " + listadeclientes.Clientes[j.Cliente - 1].Nome);
            WriteLine("Produto " + listadeprodutos.Produtos[j.Produto].Nome + " código #" + listadeprodutos.Produtos[j.Produto].Id);
            WriteLine("Unidades vendidas " + j.QtdeVendida);
            WriteLine(" ");
            WriteLine("Valor total R$" + j.Total);
        }
        PressioneAlgo();
    }

    //SELEÇÃO
    static int SelecionarFornecedor(RepositorioDeFornecedor listadefornecedores)
    {
        Clear();
        WriteLine("De qual fornecedor você deseja comprar? ");
        foreach (var j in listadefornecedores.Fornecedores)
        {
            WriteLine(j.Id + " - Nome: " + j.Nome);
        }

        int comprarDoFornecedor = Convert.ToInt32(ReadLine());

        return comprarDoFornecedor;
    }
    static int SelecionarCliente(RepositorioDeCliente listadeclientes)
    {
        Clear();
        WriteLine("Qual cliente deseja realizar a compra? ");
        foreach (var j in listadeclientes.Clientes)
        {
            WriteLine(j.Id + " - Nome: " + j.Nome);
        }
        int ClienteComprador = Convert.ToInt32(ReadLine());

        return ClienteComprador;
    }
    static string SelecionarData()
    {
        Clear();
        WriteLine("Qual a data da compra? ");
        string data = ReadLine();
        return data;
    }
    static int SelecionarProduto(RepositorioDeProduto listadeprodutos)
    {
        Clear();
        WriteLine("Qual o código do produto que você deseja vender? ");
        foreach (var j in listadeprodutos.Produtos)
        {
            WriteLine(" ");
            WriteLine("#" + j.Id + " - " + j.Nome);
            WriteLine("Valor: R$" + j.Valor);
            WriteLine("Unidades a venda: " + j.QtdeEstoque);
        }
        int produtoVendido = Convert.ToInt32(ReadLine());

        return produtoVendido;
    }

    // MENSAGENS
    static void PressioneAlgo()
    {
        WriteLine(" ");
        ReadKey();
    }
    static void TxtContinuar()
    {
        WriteLine("Deseja continuar?");
        WriteLine("1 - Sim");
        WriteLine("0 - Não");
    }

    //VENDER
    static void Vender(RepositorioDeProduto listadeprodutos, RepositorioDeCliente listadeclientes, int IdVenda, Venda venda, RepositorioDeVenda listadevendas)
    {
        int escolhaVenda = 10;
        string data = SelecionarData();

        int ClienteComprador = SelecionarCliente(listadeclientes);

        double total = 0;
        while (escolhaVenda != 0)
        {
            int produtoVendido = SelecionarProduto(listadeprodutos);

            if (listadeprodutos.Produtos.Exists(x => x.Id == produtoVendido))
            {
                WriteLine(" ");
                WriteLine("Quantas unidades deseja vender?");
                int unidadesVendidas = Convert.ToInt32(ReadLine());

                int posicaoProdutoVendido = produtoVendido - 1;

                int unidadesAVenda = listadeprodutos.Produtos[posicaoProdutoVendido].QtdeEstoque;
                double valorProdutoEscolhido = listadeprodutos.Produtos[posicaoProdutoVendido].Valor;

                if (unidadesAVenda - unidadesVendidas >= 0)
                {
                    Clear();
                    total += (valorProdutoEscolhido * unidadesVendidas);
                    WriteLine("O carrinho de compra está no valor de R$" + total);
                    venda = new Venda(IdVenda, data, ClienteComprador, posicaoProdutoVendido, unidadesVendidas, total);
                    listadevendas.InserirVenda(venda);
                    IdVenda++;
                    TxtContinuar();
                    escolhaVenda = Convert.ToInt32(ReadLine());
                    listadeprodutos.Produtos[posicaoProdutoVendido].QtdeEstoque -= unidadesVendidas;
                    Clear();

                }
                else
                {
                    Clear();
                    WriteLine("Você não possui essa quantidade no estoque");
                }
            }
            else
            {
                Clear();
                WriteLine("Esse produto não existe!");
            }
        }
    }
    static void Main(string[] args)
    {
        int IdCliente = 0;
        int IdFornecedor = 0;
        int IdProduto = 0;
        int IdVenda = 0;
        int escolha = 10;

        // construtor
        RepositorioDeCliente listadeclientes = new RepositorioDeCliente();
        RepositorioDeFornecedor listadefornecedores = new RepositorioDeFornecedor();
        RepositorioDeProduto listadeprodutos = new RepositorioDeProduto();
        RepositorioDeVenda listadevendas = new RepositorioDeVenda();
        Cliente cliente = new Cliente();
        Fornecedor fornecedor = new Fornecedor();
        Produto produto = new Produto();
        Venda venda = new Venda();

        while (escolha != 0) // Looping do menu
        {
            try // Tratamento da escolha
            {
                escolha = MostrarMenu();
            }
            catch
            {
                WriteLine("Valor inválido");
            }
            switch (escolha)
            {
                case 1: // Cliente
                    switch (MenuCliente())
                    {
                        case 1:// Cadastra cliente
                            IdCliente++;
                            CadastrarCliente(cliente, IdCliente, listadeclientes);
                            break;

                        case 2:// Listar cliente
                            Listar(listadeclientes);
                            break;
                    }

                    break;

                case 2:// Menu Fornecedor 
                    switch (MenuFornecedor())
                    {
                        case 1: // Cadastra fornecedor     
                            IdFornecedor++;
                            CadastrarFornecedor(fornecedor, IdFornecedor, listadefornecedores);
                            break;

                        case 2: // Listar fornecedor 
                            Listar(listadefornecedores);
                            break;

                        case 3:// Comprar produto
                            IdProduto++;
                            int comprarDoFornecedor = SelecionarFornecedor(listadefornecedores);
                            CadastrarProduto(listadefornecedores, comprarDoFornecedor, produto, listadeprodutos, IdProduto);
                            break;
                    }
                    break;

                case 3:// Menu Produtos
                    switch (MenuProduto())
                    {
                        case 1:// Listar Produtos
                            Listar(listadeprodutos);
                            break;
                    }
                    break;

                case 4://Menu Vender
                    if (IdCliente >= 1 && IdProduto >= 1)
                    {
                        Vender(listadeprodutos, listadeclientes, IdVenda, venda, listadevendas);
                    }
                    else
                    {
                        WriteLine("Você precisa ter ao menos um cliente e um produto para realizar uma venda!");
                        PressioneAlgo();
                    }
                    break;

                case 5:
                    Listar(listadevendas, listadeclientes, listadeprodutos);
                    break;
            }
        }
    }
}