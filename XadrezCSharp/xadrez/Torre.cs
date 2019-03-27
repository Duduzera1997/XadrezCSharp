using tabuleiro;

namespace xadrez
{
    // Extends;
    class Torre : Peca
    {

        // Construtor;
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {

        }

        // Método para verificar se é possivel mover para aquela posição;
        public bool novimentoPossivel(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != this.cor;
        }

        // Sobreposição;
        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tabuleiro.linhas, tabuleiro.colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha - 1;
            }

            // Abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.linha = pos.linha + 1;
            }

            // Direita
            pos.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna + 1;
            }

            // Esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(pos) && novimentoPossivel(pos)) {
                mat[pos.linha, pos.coluna] = true;
                if (tabuleiro.peca(pos) != null && tabuleiro.peca(pos).cor != cor) {
                    break;
                }
                pos.coluna = pos.coluna - 1;
            }

            return mat;
        }

    // Sobreposição;
    public override string ToString()
        {
            return "T";
        }


    }
}

