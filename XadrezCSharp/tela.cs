using System;
using tabuleiro;
using xadrez;

namespace XadrezCSharp
{
    class Tela
    {

        // Método static pra imprimir o Tabuleiro na tela;
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {
            //Loop pra percorrer linha a linha do tabuleiro;
            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                //Loop pra percorrer coluna a coluna do tabuleiro;
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    imprimirPeca(tabuleiro.peca(i, j));
                }
                //Quebrar a linha e montar a estrutura correta do tabuleiro;
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        // Sobrecarga para pintar o fundo com as possíveis posições de movimento daquela peça;
        public static void imprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGreen;

            //Loop pra percorrer linha a linha do tabuleiro;
            for (int i = 0; i < tabuleiro.linhas; i++) {
                Console.Write(8 - i + " ");
                //Loop pra percorrer coluna a coluna do tabuleiro;
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    if (posicoesPossiveis[i, j]) {
                        Console.BackgroundColor = fundoAlterado;
                    } else {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    imprimirPeca(tabuleiro.peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                //Quebrar a linha e montar a estrutura correta do tabuleiro;
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = fundoOriginal;
        }

        // Método pra ler a posição do xadrez;
        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        // Método pra inserir cores nas peças;
        public static void imprimirPeca(Peca peca)
        {
            // Verificar se a peça naquela linha e coluna é nula ou não, retornando a estrutura do tabuleiro;
            if (peca == null) {
                Console.Write("- ");
            } else {
                if (peca.cor == Cor.White) {
                    Console.Write(peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;

                }
                Console.Write(" ");
            }
           
        }

    }
}
