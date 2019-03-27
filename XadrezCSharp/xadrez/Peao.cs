using tabuleiro;
using xadrez;

namespace xadrez
{
    class Peao : Peca
    {

        private Partida partida;


        // Construtor;
        public Peao(Tabuleiro tabuleiro, Cor cor, Partida partida) : base(tabuleiro, cor)
        {

            this.partida = partida;

        }


        // Sobreposição;
        public override string ToString()
        {

            return "P";

        }


        // Método para verificar se existe inimigo naquela posição;
        private bool existeInimigo(Posicao pos)
        {

            Peca p = tabuleiro.peca(pos);

            return p != null && p.cor != cor;

        }


        // Método para verificar se a posição está posicaoLivre;
        private bool posicaoLivre(Posicao pos)
        {

            return tabuleiro.peca(pos) == null;

        }


        // Sobreposição;
        public override bool[,] movimentosPossiveis()
        {

            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];



            Posicao pos = new Posicao(0, 0);



            if (cor == Cor.Branca)
            {
                pos.definirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && posicaoLivre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(p2) && posicaoLivre(p2) && tabuleiro.posicaoValida(pos) && posicaoLivre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }
            else
            {
                pos.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(pos) && posicaoLivre(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 2, posicao.coluna);
                Posicao p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(p2) && posicaoLivre(p2) && tabuleiro.posicaoValida(pos) && posicaoLivre(pos) && qtdMovimentos == 0)
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
                pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(pos) && existeInimigo(pos))
                {
                    mat[pos.linha, pos.coluna] = true;
                }
            }

            return mat;

        }

    }
}

