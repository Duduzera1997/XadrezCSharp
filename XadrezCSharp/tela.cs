using System;
using System.Collections.Generic;
using System.Text;
using tabuleiro;

namespace XadrezCSharp
{
    class Tela
    {   

        // Método static pra imprimir o Tabuleiro na tela;
        public static void imprimirTabuleiro(Tabuleiro tabuleiro)
        {   
            //Loop pra percorrer linha a linha do tabuleiro;
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                Console.Write(8 - i + " ");
                //Loop pra percorrer coluna a coluna do tabuleiro;
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    
                    // Verificar se a peça naquela linha e coluna é nula ou não, retornando a estrutura do tabuleiro;
                    if (tabuleiro.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                       imprimirPeca(tabuleiro.peca(i, j));
                        Console.Write(" ");
                    }
                    

                }
                //Quebrar a linha e montar a estrutura correta do tabuleiro;
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        // Método pra inserir cores nas peças;
        public static void imprimirPeca(Peca peca)
        {
            if (peca.cor == Cor.White) {
                Console.Write(peca);
            } else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(peca);
                Console.ForegroundColor = aux;

            }
        }

    }
}
