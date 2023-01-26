using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3
{
    [System.Serializable]
    class Ebook : Produto, IEstoque
    {
        public string autor;
        private int venda;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Entrada de vendas do produto  {nome}");
            Console.WriteLine("Digite o numero de vendas do Ebook");
            int entrada = int.Parse(Console.ReadLine());
            venda += entrada;
            Console.WriteLine("Entradas de vendas registradas");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida do produto {nome}");
            Console.WriteLine($"Digite a Qtda de que você quer dar baixa");
            int entrada = int.Parse(Console.ReadLine());
            venda -= entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome: {nome}");
            Console.WriteLine($"Autor: {autor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vendas: {venda}");
            Console.WriteLine("_______________________________________");
            Console.WriteLine(" ");
        }
    }
}
