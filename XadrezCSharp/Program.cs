using System;
using tabuleiro;
using xadrez;

namespace XadrezCSharp
{
    class Program
    {   
        // Método Main;
        static void Main(string[] args)
        {   
            // Instanciando um Tabuleiro de 8 linhas e 8 colunas.
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.colocarPeca(new Torre(tab, Cor.Black), new Posicao(0, 0));
            tab.colocarPeca(new Torre(tab, Cor.Black), new Posicao(1, 3));
            tab.colocarPeca(new Rei(tab, Cor.Black), new Posicao(2, 4));

            // Usando um Método static da classe Tela;
            Tela.imprimirTabuleiro(tab);

            Console.ReadLine();
        }
    }
}
