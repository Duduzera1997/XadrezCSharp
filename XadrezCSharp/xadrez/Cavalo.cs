using tabuleiro;
using xadrez;

namespace xadrez
{
    class Cavalo : Peca
    {


        // Construtor;
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }


        // Sobreposição;
        public override string ToString()
        {

            return "C";

        }



        // Método para verificar se é possivel mover para aquela posição;
        private bool movimentoPossivel(Posicao posicao)
        {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != cor;

        }


        // Sobreposição;
        public override bool[,] movimentosPossiveis()
        {

            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];



            Posicao pos = new Posicao(0, 0);


            // Lógica de movimentos do cavalo;
            pos.definirValores(posicao.linha - 1, posicao.coluna - 2);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha - 2, posicao.coluna - 1);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha - 2, posicao.coluna + 1);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha - 1, posicao.coluna + 2);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha + 1, posicao.coluna + 2);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha + 2, posicao.coluna + 1);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha + 2, posicao.coluna - 1);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }

            pos.definirValores(posicao.linha + 1, posicao.coluna - 2);

            if (tabuleiro.posicaoValida(pos) && movimentoPossivel(pos))
            {

                mat[pos.linha, pos.coluna] = true;

            }



            return mat;

        }

    }
}
