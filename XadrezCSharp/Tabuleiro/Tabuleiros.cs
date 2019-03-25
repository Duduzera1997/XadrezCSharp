using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Tabuleiro
    {
        // Atributos com Encapsulamento;
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; // Matriz;


        // Construtor;
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        // Método com Encapsulamento para acessar um elemento da matriz;
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
    }
}
