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
            // Cláusula Try Catch para tratar exceções;
            try {
                // Instanciando um Tabuleiro de 8 linhas e 8 colunas.
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.colocarPeca(new Torre(tab, Cor.Black), new Posicao(0, 0));
                tab.colocarPeca(new Torre(tab, Cor.Black), new Posicao(1, 3));
                tab.colocarPeca(new Rei(tab, Cor.Black), new Posicao(0, 2));

                // Usando um Método static da classe Tela;
                Tela.imprimirTabuleiro(tab);

            } catch (TabuleiroException e) {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
