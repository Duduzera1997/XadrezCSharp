using System;
using System.Collections.Generic;
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

        public static void imprimirPartida(Partida partida)
        {
            Tela.imprimirTabuleiro(partida.tabuleiro);
            Console.WriteLine();
            imprimirPecasCapturadas(partida);
            Console.WriteLine("Turno: " + partida.turno);
            Console.WriteLine("Aguardando jogada: " + partida.jogadorAtual);
        }

        public static void imprimirPecasCapturadas(Partida partida)
        {
            Console.WriteLine("Peças Capturadas: ");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ConsoleColor auxiliar = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            imprimirConjunto(partida.pecasCapturadas(Cor.Preta));
            Console.ForegroundColor = auxiliar;
            Console.WriteLine();
        }

        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca p in conjunto) {
                Console.Write(p + ", ");

            }
            Console.Write("]");
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
                if (peca.cor == Cor.Branca) {
                    Console.Write(peca);
                } else {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;

                }
                Console.Write(" ");
            }
           
        }

    }
}
