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
        public bool xeque { get; private set; }


        // Construtor;
        public Partida()
        {
            this.tabuleiro = new Tabuleiro(8, 8);
            this.turno = 1;
            this.jogadorAtual = Cor.Branca;
            this.terminada = false;
            this.xeque = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            this.colocarPecas();
        }

        // Método pra executar o movimento da peça no tabuleiro;
        public Peca executarMovimento(Posicao origem, Posicao destino)
        {
            Peca peca = tabuleiro.retirarPeca(origem);
            peca.incrementarQtdMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        // Método para desfazer o movimento da jogada caso a peça estiver em Xeque;
        public void desfazerMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tabuleiro.retirarPeca(destino);
            p.decrementarQtdMovimentos();

            if (pecaCapturada != null)
            {
                tabuleiro.colocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocarPeca(p, origem);
        }

        // Método pra realizar jogada, incrementar o turno e mudar o jogador.
        public void realizarJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executarMovimento(origem, destino);
            if (verificarXeque(jogadorAtual))
            {
                desfazerMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Você não pode se colocar em Xeque!");
            }

            if (verificarXeque(verificarAdversario(jogadorAtual)))
            {
                this.xeque = true;
            }
            else
            {
                this.xeque = false;
            }

            if (verificarXequeMate(verificarAdversario(jogadorAtual)))
            {
                this.terminada = true;
            }
            else
            {
                turno++;
                mudarJogador();
            }
        }

        // Método para validar todas as possiveis exceções ao selecionar uma peça de origem;
        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if (tabuleiro.peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (jogadorAtual != tabuleiro.peca(pos).cor)
            {
                throw new TabuleiroException("A Peça escolhida, não pertence a você!");
            }

            if (!tabuleiro.peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não existem movimentos possíveis para a peça de origem escolhida!");
            }
        }

        // Método para validar a posição de destino escolhida, caso não for possível mover lança uma exceção;
        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).podeMoverParaDestinoEscolhido(destino))
            {
                throw new TabuleiroException("Posição de destino Inválida!");
            }
        }

        // Método que muda a vez do jogador de acordo com as cores;
        private void mudarJogador()
        {
            if (jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        // Método pra verificar quem são as peças capturadas de determinada cor;
        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach (Peca p in capturadas)
            {
                if (p.cor == cor)
                {
                    auxiliar.Add(p);
                }
            }
            return auxiliar;
        }

        // Método para retornar as peças em jogo de determinada cor;
        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> auxiliar = new HashSet<Peca>();
            foreach (Peca p in pecas)
            {
                if (p.cor == cor)
                {
                    auxiliar.Add(p);
                }
            }
            auxiliar.ExceptWith(pecasCapturadas(cor));
            return auxiliar;
        }

        // Método para verificar o Adversário de determinada cor;
        private Cor verificarAdversario(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        // Método para verificar o Rei daquela determinada cor;
        private Peca verificarRei(Cor cor)
        {
            foreach (Peca p in pecasEmJogo(cor))
            {

                // Verificando se uma variável P é uma instância da SubClasse Rei com a palavra "is";
                if (p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        // Verificar se o Rei está em Xeque;
        public bool verificarXeque(Cor cor)
        {
            Peca rei = verificarRei(cor);

            if (rei == null)
            {
                throw new TabuleiroException("Não existe um rei da cor " + cor + " no Tabuleiro!");
            }
            foreach (Peca p in pecasEmJogo(verificarAdversario(cor)))
            {
                bool[,] matAux = p.movimentosPossiveis();

                if (matAux[rei.posicao.linha, rei.posicao.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        // Método para verificar se o jogador daquela cor está em Xeque Mate;
        public bool verificarXequeMate(Cor cor)
        {
            if (!verificarXeque(cor))
            {
                return false;
            }

            foreach (Peca p in pecasEmJogo(cor))
            {
                bool[,] mat = p.movimentosPossiveis();
                for (int i = 0; i < tabuleiro.linhas; i++)
                {
                    for (int j = 0; j < tabuleiro.colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = p.posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executarMovimento(origem, destino);
                            bool testeXeque = verificarXeque(cor);
                            desfazerMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
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
