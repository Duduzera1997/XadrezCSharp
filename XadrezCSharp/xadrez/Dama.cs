using tabuleiro;
using xadrez;

namespace xadrez
{
    class Dama : Peca
    {


        // Construtor;
        public Dama(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }


        // Sobreposição;
        public override string ToString()
        {

            return "D";

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



            // Esquerda

            pos.definirValores(posicao.linha, posicao.coluna - 1);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha, pos.coluna - 1);

            }



            // Direita

            pos.definirValores(posicao.linha, posicao.coluna + 1);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha, pos.coluna + 1);

            }



            // Acima

            pos.definirValores(posicao.linha - 1, posicao.coluna);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha - 1, pos.coluna);

            }



            // Abaixo

            pos.definirValores(posicao.linha + 1, posicao.coluna);

            while (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor)
                {

                    break;

                }

                pos.definirValores(pos.linha + 1, pos.coluna);

            }



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



            // Sudeste

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



            // Sudoeste

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
