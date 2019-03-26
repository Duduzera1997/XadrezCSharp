using System.Collections.Generic;
using tabuleiro;
using exceptions;

namespace xadrez
{
    class Partida
    {   
        // Atributos;
        public Tabuleiro tabuleiro { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;


        // Construtor;
        public Partida()
        {
            this.tabuleiro = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            this.terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            this.colocarPecas();
        }

        // Método pra executar o movimento da peça no tabuleiro;
        public void executarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
        }

        // Método pra realizar jogada, incrementar o turno e mudar o jogador.
        public void realizarJogada(Posicao origem, Posicao destino)
        {
            executarMovimento(origem, destino);
            turno++;
            mudarJogador();
        }

        // Método para validar todas as possiveis exceções ao selecionar uma peça de origem;
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tabuleiro.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (jogadorAtual != tabuleiro.peca(pos).cor) {
                throw new TabuleiroException("A Peça escolhida, não pertence a você!");
            }

            if (!tabuleiro.peca(pos).existeMovimentosPossiveis()) {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça de origem escolhida!");
            }
        }

        // Método para validar a posição de destino escolhida, caso não for possível mover lança uma exceção;
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).podeMoverParaDestinoEscolhido(destino)) {
                throw new TabuleiroException("Posição de destino Inválida!");
            }
        }

        // Método que muda a vez do jogador de acordo com as cores;
        private void mudarJogador()
        {
            if (jogadorAtual == Cor.Branca) {
                jogadorAtual = Cor.Preta;
            } else {
                jogadorAtual = Cor.Branca;
            }
        }

        // Método pra verificar quem são as peças capturadas de determinada cor;
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach (Peca p in capturadas) {
                if (p.cor == cor) {
                    auxiliar.Add(p);
                }
            }
            return auxiliar;
        }

        // Método para retornar as peças em jogo de determinada cor;
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach (Peca p in pecas) {
                if (p.cor == cor) {
                    auxiliar.Add(p);
                }
            }
            auxiliar.ExceptWith(pecasCapturadas(cor));
            return auxiliar;
        }
        
        // Método pra inserir uma nova peça no tabuleiro;
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).converterPosicao());
            pecas.Add(peca);
        }
 
        //Método para colocar a peça no tabuleiro contendo Encapsulamento;
        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.Preta));

        }
    }
}
