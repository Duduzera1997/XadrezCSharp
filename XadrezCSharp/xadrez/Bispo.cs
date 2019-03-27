﻿using tabuleiro;
using xadrez;

namespace XadrezCSharp.xadrez
{
    class Bispo : Peca
    {


        // Construtor
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }


        // Sobreposição;
        public override string ToString()
        {

            return "B";

        }


        // Método para verificar se é possivel mover para aquela posição;
        private bool movimentoPossivel(Posicao posicao)
        {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;

        }



        public override bool[,] movimentosPossiveis()
        {

            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];



            Posicao pos = new Posicao(0, 0);



            // Norte

            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha - 1, pos.coluna - 1);

            }



            // Nordeste

            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha - 1, pos.coluna + 1);

            }



            // SE

            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha + 1, pos.coluna + 1);

            }



            // SO

            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha + 1, pos.coluna - 1);

            }



            return mat;

        }

    }
}
