using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace ListaSupermercado
{
    class Calculo
    {

        public BindingList<Produto> produtos = new BindingList<Produto>();
        public List<String> emails = new List<String>();
        public int total;

        public void preencherLista(string caminhop)
        {
            if (!File.Exists(caminhop))
            {
                Console.WriteLine("Lista de produtos não encontrada!");
                Environment.Exit(0);
            }

            int length = File.ReadAllLines(caminhop).Count();
            StreamReader f = new StreamReader(caminhop, Encoding.UTF7);
            for (int i = 0; i < length; i++)
            {
                string linha = f.ReadLine();
                string[] campos = linha.Split(';');
                Produto p = new Produto()
                {
                    Nome = campos[0],
                    Qtd = int.Parse(campos[1]),
                    PrecoUnitario = int.Parse(campos[2])
                };
                total += p.PrecoUnitario * p.Qtd;
                produtos.Add(p);
            }
            Console.WriteLine("Valor total: " + total.ToString());
            f.Close();
        }

        public void preencherEmail(string caminhoE)
        {
            if (!File.Exists(caminhoE))
            {
                Console.WriteLine("Lista de emails não encontrada!");
                Environment.Exit(0);
            }

            int length = File.ReadAllLines(caminhoE).Count();
            StreamReader f = new StreamReader(caminhoE, Encoding.UTF7);
            for (int i = 0; i < length; i++)
            {
                string linha = f.ReadLine();
                string[] campos = linha.Split(';');
                string p = campos[0];
                
                emails.Add(p);
            }
            f.Close();
        }

        public void exibir()
        {
            var map = new Dictionary<string, int>();

            int vParcial = total / emails.Count;
            List<int> valores = new List<int>();
            
            foreach (var email in emails)
            {
                valores.Add(vParcial);
            }
            int length = valores.Count;

            if (total != (vParcial * emails.Count))
            {
                int resto = (total - vParcial * emails.Count);

                for (var i = 1; i < resto + 1; i++)
                {
                    valores[length - i]++;
                }
            }

            for (int i = 0; i < valores.Count; i++)
            {
                map.Add(emails[i], valores[i]);
            }


            foreach (var unic in map)
            {
                string key = unic.Key;
                string value = unic.Value.ToString();

                Console.WriteLine("\n" + key + " Irá pagar => " + value);

            }



        }

    }
}
