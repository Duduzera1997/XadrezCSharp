using System;
using tabuleiro;

namespace XadrezCSharp
{
    class Program
    {   
        // Método Main;
        static void Main(string[] args)
        {   
            // Instanciando um Tabuleiro de 8 linhas e 8 colunas.
            Tabuleiro tab = new Tabuleiro(8, 8);

            // Usando um Método static da classe Tela;
            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
