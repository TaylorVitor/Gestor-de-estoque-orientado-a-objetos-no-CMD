using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_3
{
    [System.Serializable]
    class Musica : Produto, IEstoque
    {
        public string cantor;
        private int vizualizacao;

        public Musica(string nome, float preco, string cantor)
        {
            this.nome = nome;
            this.preco = preco;
            this.cantor = cantor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Entrada de vizualização do produto {nome}");
            Console.WriteLine($"Digite o numero de vizualizações");
            int entrada = int.Parse(Console.ReadLine());
            vizualizacao += entrada;
            Console.WriteLine("Numero de vizualizações registradas");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida do produto {nome}");
            Console.WriteLine($"Digite a Qtda de que você quer dar baixa");
            int entrada = int.Parse(Console.ReadLine());
            vizualizacao -= entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome da musica: {nome}");
            Console.WriteLine($"Cantor: {cantor}");
            Console.WriteLine($"Preço: {preco}");
            Console.WriteLine($"Vizualização: {vizualizacao}");
            Console.WriteLine("_______________________________________");
            Console.WriteLine(" ");
        }
    }
}
