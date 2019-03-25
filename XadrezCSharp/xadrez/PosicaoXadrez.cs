using tabuleiro;

namespace xadrez
{
    class PosicaoXadrez
    {   
        // Atributos;
        public char coluna { get; set; }
        public int linha { get; set; }


        // Construtor;
        public PosicaoXadrez(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;
        }

        // Método pra converter posição de acordo com a posição da matriz;
        public Posicao converterPosicao()
        {
            return new Posicao(8 - linha, coluna - 'a');
        }

        // Sobreposição
        public override string ToString()
        {
            return "" + coluna + linha;
        }
    }
}
