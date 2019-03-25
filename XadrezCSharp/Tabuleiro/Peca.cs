
namespace tabuleiro
{
    class Peca
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
    }
}
