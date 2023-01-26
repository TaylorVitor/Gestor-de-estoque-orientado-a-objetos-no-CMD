using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Projeto_3
{
    class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu {Lista = 1, Adicionar, Remover, Entra, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool escolherSair = false;
            while(escolherSair == false)
            {
                Console.WriteLine("Gerenciamento do estoque");
                Console.WriteLine("1-Lista \n2-Adicionar \n3-Remover \n4-Entrada de estoque \n5-Saída de estoque \n6-Sair");
                string opStrg = Console.ReadLine();
                int opInt = int.Parse(opStrg);
                Menu Choose = (Menu)opInt;

                if (opInt > 0 && opInt < 7)
                {
                    switch (Choose)
                    {
                        case Menu.Lista:
                            Listagem();
                            break;

                        case Menu.Adicionar:
                            Cadastrar();
                            break;

                        case Menu.Remover:
                            Remover();
                            break;

                        case Menu.Entra:
                            Entrada();
                            break;

                        case Menu.Saida:
                            Saida();
                            break;

                        case Menu.Sair:
                            escolherSair = true;
                            break;
                    }
                } else
                {
                    Console.WriteLine("Opção não encotrada");
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }

        static void Cadastrar()
        {
            Console.WriteLine("1-Produto fisico \n2-Musica \n3-Ebook \n4-Curso");
            string strOpc = Console.ReadLine();
            int intOpc = int.Parse(strOpc);

            switch (intOpc)
            {
                case 1:
                    ProdutoFisico();
                    break;

                case 2:
                    Musica();
                    break;

                case 3:
                    Ebook();
                    break;

                case 4:
                    Curso();
                    break;
            }
        }

        

        static void Listagem()
        {
            Console.WriteLine("Lista de produtos cadastrados");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer deletar");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar de entrada");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        static void ProdutoFisico()
        {
            Console.WriteLine("Cadastro do produto fisico");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: ");
            int frete = int.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void Musica()
        {
            Console.WriteLine("Cadastro de musica");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Cantor:");
            string cantor = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            

            Musica ms = new Musica(nome, preco, cantor);
            produtos.Add(ms);
            Salvar();
        }

        static void Ebook()
        {
            Console.WriteLine("Cadastro de Ebook");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void Curso()
        {
            Console.WriteLine("Cadastro de Curso");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("Produtos.dat",FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close();
        }

        static void Carregar()
        {
                FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
                BinaryFormatter encoder = new BinaryFormatter();
            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch (Exception)
            {
                produtos = new List<IEstoque>();
            }
            stream.Close();
        }
    }
}
