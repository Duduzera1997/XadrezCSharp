using tabuleiro;

namespace xadrez
{
    class Partida
    {   
        // Atributos;
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        // Construtor;
        public Partida()
        {
            this.tabuleiro = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.White;
            this.terminada = false;
            this.colocarPecas();
        }

        // Método pra executar o movimento da peça no tabuleiro;
        public void executarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }

        //Método para colocar a peça no tabuleiro contendo Encapsulamento;
        private void colocarPecas()
        {
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.White), new PosicaoXadrez('c', 1).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.White), new PosicaoXadrez('c', 2).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.White), new PosicaoXadrez('d', 2).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.White), new PosicaoXadrez('e', 2).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.White), new PosicaoXadrez('e', 1).converterPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.White), new PosicaoXadrez('d', 1).converterPosicao());

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Black), new PosicaoXadrez('c', 7).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Black), new PosicaoXadrez('c', 8).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Black), new PosicaoXadrez('d', 7).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Black), new PosicaoXadrez('e', 7).converterPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Black), new PosicaoXadrez('e', 8).converterPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Black), new PosicaoXadrez('d', 8).converterPosicao());

        }
    }
}
