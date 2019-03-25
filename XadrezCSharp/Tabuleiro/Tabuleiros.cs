using exceptions;

namespace tabuleiro
{
    class Tabuleiro
    {
        // Atributos com Encapsulamento;
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas; // Matriz;


        // Construtor;
        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        // Método com Encapsulamento para acessar um elemento da matriz;
        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        // Sobrecarga do método peça;
        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.linha, posicao.coluna];
        }

        // Método para verificar se existe uma peça naquela posição;
        public bool existePeca(Posicao posicao)
        {
            validarPosicao(posicao);
            return peca(posicao) != null;
        }

        // Método para inserir uma Peça no Tabuleiro;
        public void colocarPeca(Peca peca, Posicao posicao)
        {
            if (existePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nesta posição!");
            }
            pecas[posicao.linha, posicao.coluna] = peca;
            peca.posicao = posicao;
        }

        //Método pra retirar uma Peça do Tabuleiro;
        public Peca retirarPeca(Posicao posicao)
        {
            if (peca(posicao) == null) {
                return null;
            }
            Peca aux = peca(posicao);
            aux.posicao = null;
            pecas[posicao.linha, posicao.coluna] = null;
            return aux;
        }

        // Método para verificar se a posição informada é válida de acordo com o tamanho do tabuleiro.
        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.linha < 0 || posicao.linha >= linhas || posicao.coluna < 0 || posicao.coluna >= this.colunas)
            {
                return false;
            }
            return true;
        }

        // Método para validar a posição e retornar uma exception caso for inválida.
        public void validarPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
            {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
