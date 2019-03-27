using tabuleiro;

namespace xadrez
{
    // Extends;
    class Rei : Peca
    {
        private Partida partida;

        // Constutor;
        public Rei(Tabuleiro tabuleiro, Cor cor, Partida partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
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

        // Método para verificar se a torre é elegível para Roque;
        private bool testarTorreParaRoque(Posicao pos)
        {
            Peca p = tabuleiro.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimentos == 0;
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

            // Jogada Especial Roque;

            if (qtdMovimentos == 0 && !partida.xeque)
            {
                // Roque Pequeno;
                Posicao pos1 = new Posicao(posicao.linha, posicao.coluna + 3);

                if (testarTorreParaRoque(pos1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);

                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        mat[posicao.linha, posicao.coluna + 2] = true;
                    }
                }

                // Roque Grande;
                Posicao pos2 = new Posicao(posicao.linha, posicao.coluna - 4);

                if (testarTorreParaRoque(pos2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);

                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        mat[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
