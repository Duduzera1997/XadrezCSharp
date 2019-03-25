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
                //Loop pra percorrer coluna a coluna do tabuleiro;
                for (int j = 0; j < tabuleiro.colunas; j++) {
                    
                    // Verificar se a peça naquela linha e coluna é nula ou não, retornando a estrutura do tabuleiro;
                    if (tabuleiro.peca(i, j) == null) {
                        Console.Write("- ");
                    }
                    else {
                        Console.Write(tabuleiro.peca(i, j) + " ");
                    }
                    

                }
                //Quebrar a linha e montar a estrutura correta do tabuleiro;
                Console.WriteLine();
            }
        }

    }
}
