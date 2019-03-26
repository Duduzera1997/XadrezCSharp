using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Posicao
    {

        // Atributos com Encapsulamento;
        public int linha { get; set; }
        public int coluna { get; set; }


        // Construtor & Palavra de autorreferência this;
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }

        // Define o valores das linhas e colunas;
        public void definirValores(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;
        }
        
        // Sobreposição;
        public override string ToString()
        {
            return linha + ", " + coluna;
        }
    }
}
