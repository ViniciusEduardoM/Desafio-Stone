using System;

namespace ListaSupermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculo = new Calculo();
            Console.WriteLine("Coloque aqui o caminho da sua lista de produtos: ");

            string caminhop = Console.ReadLine();
            calculo.preencherLista(caminhop);

            Console.WriteLine("Coloque aqui o caminho da lista de emails: ");

            string caminhoE = Console.ReadLine();
            calculo.preencherEmail(caminhoE);

            calculo.exibir();

        }
    }
}
