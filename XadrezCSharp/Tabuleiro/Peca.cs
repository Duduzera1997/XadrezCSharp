using System;
using System.Collections.Generic;
using System.Text;

namespace tabuleiro
{
    class Peca
    {   
        // Atributos com Encapsulamento;
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }


        // Construtor;
        public Peca(Posicao posicao, Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = posicao;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
        }
    }
}
