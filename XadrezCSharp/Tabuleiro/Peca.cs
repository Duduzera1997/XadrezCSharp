
namespace tabuleiro
{
    abstract class Peca
    {   
        // Atributos com Encapsulamento;
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }


        // Construtor;
        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.qtdMovimentos = 0;
        }

        // Método para incrementar a quantidade de movimentos do jogador;
        public void incrementarQtdMovimentos()
        {
            this.qtdMovimentos++;
        }

        // Método para decrementar a quantidade de movimentos do jogador;
        public void decrementarQtdMovimentos()
        {
            this.qtdMovimentos--;
        }

        // Método pra verificar se existe movimentos possíveis pra determinada peça.
        public bool existeMovimentosPossiveis()
        {
            bool[,] mov = movimentosPossiveis();

            for (int i = 0; i < tabuleiro.linhas; i++) {
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (mov[i,j]) {
                        return true;
                    }
                }
            }
            return false;
        }

        // Método pra verificar se pode mover a peça para o destino escolhido
        public bool podeMoverParaDestinoEscolhido(Posicao pos)
        {
            return movimentosPossiveis()[pos.linha, pos.coluna];
        }

        // Método Abstrato;
        public abstract bool[,] movimentosPossiveis();
        
    }
}
