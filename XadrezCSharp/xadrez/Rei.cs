using tabuleiro;

namespace xadrez
{
    // Extends;
    class Rei : Peca
    {

        // Constutor;
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        // Sobreposição;
        public override string ToString()
        {
            return "R";
        }

        // Método para verificar se é possivel mover para aquela posição;
        private bool novimentoPossivel(Posicao posicao)
        {
            Peca p = tabuleiro.peca(posicao);
            return p == null || p.cor != this.cor;
        }


        // Sobreposição;
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }
            // Nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
            }

            return mat;
        }
    }
}
