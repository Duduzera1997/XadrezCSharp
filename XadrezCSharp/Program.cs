using System;
using tabuleiro;
using xadrez;
using exceptions;

namespace XadrezCSharp
{
    class Program
    {
        // Método Main;
        static void Main(string[] args)
        {

            try {
                // Instanciando um Tabuleiro de 8 linhas e 8 colunas.
                Partida partida = new Partida();

                while (!partida.terminada) {
                    Console.Clear();
                    // Usando um Método static da classe Tela;
                    Tela.imprimirTabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().converterPosicao();

                    bool[,] posicoesPossiveis = partida.tabuleiro.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro, posicoesPossiveis);

                    Console.WriteLine();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().converterPosicao();

                    partida.executarMovimento(origem, destino);
                }

               

            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
