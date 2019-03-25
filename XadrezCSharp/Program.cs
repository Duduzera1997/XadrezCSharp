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

            // Testando o posicionamento correto do xadrez.
            PosicaoXadrez posicao = new PosicaoXadrez('a', 1);

            Console.WriteLine(posicao);

            Console.WriteLine(posicao.converterPosicao());

            Console.ReadLine();
        }
    }
}
