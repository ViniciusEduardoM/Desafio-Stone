using System;
using System.Collections.Generic;
using System.Text;

namespace ListaSupermercado
{
    class Produto
    {
        private string nome;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int precoUnitario;

        public int PrecoUnitario
        {
            get { return precoUnitario; }
            set { precoUnitario = value; }
        }
        private int qtd;

        public int Qtd
        {
            get { return qtd; }
            set { qtd = value; }
        }

        public Produto(string nome, int qtd, int precoUnitario)
        {
            this.nome = nome;
            this.qtd = qtd;
            this.precoUnitario = precoUnitario;
        }

        public Produto() : this("", 0, 0)
        {

        }
    }
}
